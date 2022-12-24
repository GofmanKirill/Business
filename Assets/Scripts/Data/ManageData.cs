
using UnityEngine;

public class ManageData: MonoBehaviour
{
    private static Data _data = new Data();
    private const string NAME_SAVE = "DataSave";

    private void Awake()
    {
        LoadData();
    }


    private void OnApplicationPause(bool pause)
    {
        SaveData();
    }


    public static void SaveData()
    {
        PlayerPrefs.SetString(NAME_SAVE, JsonUtility.ToJson(_data));
    }



    public static void LoadData()
    {
        if (!PlayerPrefs.HasKey(NAME_SAVE))
            return;

        _data = JsonUtility.FromJson<Data>(PlayerPrefs.GetString(NAME_SAVE));
    }



    public static Data Data()
    {
        return _data;
    }

}
