using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "Blaze", menuName = "Reaper/Blaze")]
public class SBlaze : SerializedScriptableObject
{
    [SerializeField] protected string ClanName = "Reaper";
    [SerializeField] protected string[] otherMembers;

    [Button("Log Other Members")]
    private void PrintOtherMemberNames()
    {
        foreach (var name in otherMembers)
        {
            Debug.Log(name + " Reaper");
        }
    }
}
