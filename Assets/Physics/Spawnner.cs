using Sirenix.OdinInspector;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    [SerializeField] GameObject twoDObj;

    [Button]
    private void Spawn()
    {
        Instantiate(twoDObj, transform.position, Quaternion.identity);
    }
}
