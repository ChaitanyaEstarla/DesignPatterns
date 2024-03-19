using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAddressableAsset : MonoBehaviour
{
    [SerializeField] private AssetReference lowPolyEnv;
    [SerializeField] private AssetLabelReference lowPolyEnvLabel;
    [SerializeField] private AssetReferenceGameObject lowPolyGameObject;

    private GameObject loadedAsset;
    private List<GameObject> gameObjects = new();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            /*
            Addressables.LoadAssetsAsync<Object>(lowPolyEnvLabel, asyncoperationhandle =>
            {
                if (asyncoperationhandle.status == asyncoperationstatus.succeeded)
                {
                    instantiate(asyncoperationhandle.result);
                }
                else
                {
                    debug.log("failed to load");
                }
            };*/
            /*//Using Label
            Addressables.LoadAssetsAsync<Object>(lowPolyEnvLabel, objects =>
            {

            }).Completed += (asyncoperationhandle) =>
            {
                if (asyncoperationhandle.Status == AsyncOperationStatus.Succeeded)
                {
                    foreach (GameObject GO in asyncoperationhandle.Result)
                    {
                        Instantiate(GO);
                    }
                }
                else
                {
                    Debug.Log("failed to load");
                }
            };*/
            /*//using asset reference
                        lowPolyEnv.LoadAssetAsync<GameObject>().Completed += (asyncoperationhandle) =>
                        {
                            if (asyncoperationhandle.Status == AsyncOperationStatus.Succeeded)
                            {
                                Instantiate(asyncoperationhandle.Result);
                            }
                            else
                            {
                                Debug.Log("failed to load");
                            }
                        };*/
            /*//Using asset reference but no lambda function
                        AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>("Low Poly Environment");
                        asyncOperationHandle.Completed += AsyncOperationCompleted;*/
            /*//
            Addressables.LoadAssetAsync<GameObject>(lowPolyEnv);
            lowPolyEnv.InstantiateAsync().Completed += (asyncOperation) => loadedAsset = asyncOperation.Result;*/
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            //Unload Part
            Addressables.Release(loadedAsset);
        }
    }
    
    private void AsyncOperationCompleted(AsyncOperationHandle<GameObject> asyncOperationHandle)
    {
        if(asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Instantiate(asyncOperationHandle.Result);
        }
        else
        {
            Debug.Log("Failed to Load");
        }
    }
}