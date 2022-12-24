
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected Transform _targetSpawn;




    public virtual void SpawnObject(BusinessSO business,int id)
    {
        GameObject bs = Instantiate(_prefab, _targetSpawn);

        bs.GetComponent<Business>().Initialize(business, id);
    }


    public virtual void SpawnObject(UpgradeBusinessSO upgradeBusiness, Business business, int id)
    {
        GameObject bs = Instantiate(_prefab, _targetSpawn);

        bs.GetComponent<Upgrade>().Initialize(upgradeBusiness, business,id);
    }
}
