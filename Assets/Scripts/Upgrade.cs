using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _profitText;
    [SerializeField] private TextMeshProUGUI _priceText;

    public Business Business { get; set; }
    public UpgradeBusinessSO UpgradeBusinessSO { get; set; }
    public int Id { get; set; }








    public void Initialize(UpgradeBusinessSO upgradeBusiness, Business business, int id)
    {
        Business = business;
        Id = id;

        UpgradeBusinessSO = upgradeBusiness;

        _nameText.text = upgradeBusiness.nameUpgrade;
        _profitText.text = $"Доход: {upgradeBusiness.percentProfit}%";

        PurchasedUpgrade();
    }


    public void BuyUpgrade()
    {
        ManageData.SaveData();

        if (Balance.CheckBalance(UpgradeBusinessSO.price)) return;

        Balance.instanse.UpdateBalance(-UpgradeBusinessSO.price);

        ManageData.Data().PurchaseUpgrade(Business.Id,Id);

        PurchasedUpgrade();
    }



    public void PurchasedUpgrade()
    {

        if (ManageData.Data()._dataBusinesses[Business.Id]._dataUpgrades[Id].Purchased)
        {
            _priceText.text = $"Куплено";
            GetComponent<Button>().interactable = false;
        }
        else _priceText.text = $"Цена: {UpgradeBusinessSO.price}$";

        Business.UpdateText();
    }
}
