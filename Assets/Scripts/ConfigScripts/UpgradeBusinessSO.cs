
using UnityEngine;

[CreateAssetMenu(fileName = nameof(UpgradeBusinessSO), menuName = "Configs/" + nameof(UpgradeBusinessSO), order = 1)]
public class UpgradeBusinessSO : ScriptableObject
{
    [SerializeField] internal string nameUpgrade;
    [SerializeField] internal int price;
    [SerializeField] internal int percentProfit;
}
