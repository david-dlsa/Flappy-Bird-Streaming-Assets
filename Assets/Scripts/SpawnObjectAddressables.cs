using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


[System.Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid) : base(guid)
    {
    }
}

public class SpawnObjectAddressables : MonoBehaviour
{
    [SerializeField] private AssetReference assetReference;
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] private AssetReferenceAudioClip assetReferenceAudioClip;
    [SerializeField] private AssetReferenceSprite assetReferenceSprite;
    [SerializeField] private AssetLabelReference assetLabelReference;

    private GameObject spawnedGameObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            /*Addressables.LoadAssetsAsync<Sprite>(assetLabelReference, (sprite) => {
                Debug.Log(sprite);
            });*/


            //assetReferenceGameObject.InstantiateAsync().Completed += (AsyncOperation) => spawnedGameObject = AsyncOperation.Result ;

            assetReferenceGameObject.InstantiateAsync();
            /*
            assetReferenceGameObject.LoadAssetAsync<GameObject>().Completed += 
                (asyncOperationHandle) =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        Instantiate(asyncOperationHandle.Result);
                    }
                    else
                    {
                        Debug.Log("Failed to load!");
                    }
                };
            */
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            assetReferenceGameObject.ReleaseInstance(spawnedGameObject);
        }
    }
}
