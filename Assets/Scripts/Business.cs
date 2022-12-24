
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Business : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private TextMeshProUGUI _profitText;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Slider _progressSlider;

    public BusinessSO BusinessSO { get; set; }
    public int Id { get; set; }


    public void Initialize(BusinessSO business, int id )
    {
        AddBusiness(id);

        Id = id;

        BusinessSO = business;

        GetComponent<CreateUpgrade>().SpawnBusinessList(business.upgrade, this);

        _nameText.text = business.nameBusiness;
        UpdateText();

        _progressSlider.maxValue = business.timeProfit;
    }



    private void Update()
    {
        AddProfit();
    }
    private void AddProfit()
    {
        if (ManageData.Data()._dataBusinesses[Id].Level == 0) return;

        _progressSlider.value += Time.deltaTime;
        if (_progressSlider.value == _progressSlider.maxValue)
        {
            _progressSlider.value = 0;
            Balance.instanse.UpdateBalance(Profit());
        }
    }





    private void AddBusiness(int id)
    {
        if (ManageData.Data()._dataBusinesses.Count > id) return;
        
        if(id == 0)ManageData.Data().AddBusiness(1);
        else ManageData.Data().AddBusiness();
    }




    private int Profit()
    {
        float profit = 0;
        int lvl = ManageData.Data()._dataBusinesses[Id].Level;
        int baseProfit = BusinessSO.baseProfit;


        profit = lvl * baseProfit * UpgradeBonus();
        return (int)profit;
    }
    private float UpgradeBonus()
    {
        float bonus = 0;

        for (int i = 0; i < BusinessSO.upgrade.Length; i++)
        {
            if (ManageData.Data()._dataBusinesses[Id]._dataUpgrades[i].Purchased)
            {
                bonus += BusinessSO.upgrade[i].percentProfit / 100f;
            }
        }
        return bonus+1;
    }
    private int LevelPrice()
    {
        int lvl = ManageData.Data()._dataBusinesses[Id].Level;
        int price = (lvl + 1) * BusinessSO.basePrice;

        return price;
    }





    public void LevelUp()
    {
        if (Balance.CheckBalance(LevelPrice())) return;

        Balance.instanse.UpdateBalance(-LevelPrice());
        ManageData.Data().PurchaseLevelBusiness(Id);
        UpdateText();
    }



    public void UpdateText()
    {
        _levelText.text = $"LVL \n {ManageData.Data()._dataBusinesses[Id].Level}";
        _priceText.text = $"Цена: {LevelPrice()}$";
        _profitText.text = $"Доход \n {Profit()}$";
    }
}
