using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class BundleWebLoader : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(GetAssetBundle());
    }

    IEnumerator GetAssetBundle()
    {
        UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle("http://localhost/assetbundles/testbundle");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
        }
    }
}
