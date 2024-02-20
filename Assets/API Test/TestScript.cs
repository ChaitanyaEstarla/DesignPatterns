using System.Text;
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class TestScript : MonoBehaviour
{
    [SerializeField] private string URL;
    [SerializeField] private string authorizationKey;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="requestData"></param>
    /// <returns></returns>
    public IEnumerator StartSaveAvatarData(string requestData)
    {
            byte[] jsonByte = Encoding.UTF8.GetBytes(requestData);
            using (UnityWebRequest request = new(URL + "assignAvatarsToChild", "POST"))
            {
                request.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonByte);
                request.SetRequestHeader("Authorization", authorizationKey);
                request.SetRequestHeader("Content-Type", "application/json");
                request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
                yield return request.SendWebRequest();

                if (request.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError(request.error);
                    var errorMessage = request.downloadHandler.text;
                    Debug.LogError(errorMessage);
                }
                else
                {
                    //string responseData = JsonConvert.DeserializeObject<string>(request.downloadHandler.text);
                }
            }
    }
}
