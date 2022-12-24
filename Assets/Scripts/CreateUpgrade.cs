

public class CreateUpgrade : CreateObject
{
    public void SpawnBusinessList(UpgradeBusinessSO[] upgradeBusinesses,Business business)
    {
        for (int i = 0; i < upgradeBusinesses.Length; i++)
        {
            SpawnObject(upgradeBusinesses[i], business, i);
        }
    }

}
