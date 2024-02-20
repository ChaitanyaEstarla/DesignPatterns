using UnityEngine;

public class JSONSerializer : MonoBehaviour
{
    PlayerProfile playerProfile = new PlayerProfile();

    private void Start()
    {
        playerProfile.currency = 666;
        playerProfile.percentage = 69.69f;
        playerProfile.experience = 2;
        playerProfile.playerName = "Blaze Reaper";

        string jsonCandidate = JsonUtility.ToJson(playerProfile);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/MyJson.json", jsonCandidate);

        if (SerializationManager.Save("PlayerProfileData", jsonCandidate))
        {
            Debug.Log(jsonCandidate);
        }
    }
}
