
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Data
{
    [SerializeField] private int _balance = 0;
    public int CurrentBalance { get { return _balance; } }

    public List<DataBusiness> _dataBusinesses=new List<DataBusiness>();






    public void AddBusiness(int lvl = 0)
    {
        DataBusiness dataBusiness = new DataBusiness() { Level = lvl };
        dataBusiness._dataUpgrades = new List<DataUpgrade>() { new DataUpgrade(),new DataUpgrade()};
        Debug.Log("*"+dataBusiness._dataUpgrades.Count);
        _dataBusinesses.Add(dataBusiness);
    }



    public void PurchaseUpgrade(int idBusiness,int idUpgrade)
    {
        _dataBusinesses[idBusiness]._dataUpgrades[idUpgrade].Purchased = true;
    }
    public void PurchaseLevelBusiness(int idBusiness)
    {
        _dataBusinesses[idBusiness].Level++;
    }



    public void UpdateBalance(int value)
    {
        _balance += value;
    }
}





[System.Serializable]
public class DataBusiness
{
    [SerializeField] private int _lvl = 0;
    public int Level { get { return _lvl; } set { _lvl = value; } }


    public List<DataUpgrade> _dataUpgrades = new List<DataUpgrade>(); 
}





[System.Serializable]
public class DataUpgrade
{
    [SerializeField] private bool _purchased = false;
    public bool Purchased { get { return _purchased; } set { _purchased = value; } }
}