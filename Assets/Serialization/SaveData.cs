using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData instance;
    public static SaveData Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SaveData();
            }
            return instance; 
        }
    }

    public PlayerProfile profile;
    public int toyCars;
    public int toyDolls;



}
