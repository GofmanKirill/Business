
using UnityEngine;

[CreateAssetMenu(fileName = nameof(BusinessSO), menuName = "Configs/" + nameof(BusinessSO), order = 0)]
public class BusinessSO : ScriptableObject
{
    [SerializeField] internal string nameBusiness;
    [SerializeField] internal float timeProfit;
    [SerializeField] internal int baseProfit;
    [SerializeField] internal int basePrice;
    [SerializeField] internal UpgradeBusinessSO[] upgrade;
}
