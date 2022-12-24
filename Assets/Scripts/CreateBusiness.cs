using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBusiness : CreateObject
{
    [SerializeField] private BusinessSO[] _businessSOs;



    void Start()
    {
        SpawnBusinessList();
    }


    private void SpawnBusinessList()
    {
        for (int i = 0; i < _businessSOs.Length; i++)
        {
            SpawnObject(_businessSOs[i],i);
        }
    }

}
