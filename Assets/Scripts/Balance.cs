using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    internal static Balance instanse;

    [SerializeField]private TextMeshProUGUI _balanceText;



    void Start()
    {
        instanse = this;

        UpdateBalance(0);
    }

    public static bool CheckBalance(int price)
    {
        if (price <= ManageData.Data().CurrentBalance) return false;
        else return true;
    }

    public void UpdateBalance(int value)
    {
        ManageData.Data().UpdateBalance(value);

        _balanceText.text = $"Баланс: {ManageData.Data().CurrentBalance}$";
    }

}
