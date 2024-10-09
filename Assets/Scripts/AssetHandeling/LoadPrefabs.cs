using System.Collections;
using UnityEngine;

public class LoadPrefabs : ScriptableObject
{
    
    public static GameObject[] TowerPrefabs { get; private set; }
    public static GameObject[] EnemyPrefabs { get; private set; }
    public static GameObject[] UIPrefabs { get; private set; }

    private GameObject[] towerAssetNames = { };
    private GameObject[] enemyAssetNames = { };
    private GameObject[] uiAssetNames = { };

    AssetBundle bundle;

    private void Start()
    {
        
        
    }

    //IEnumerator loadAssetBundles()
    //{
    //    AssetBundle assetBundle = AssetBundle.LoadFromFile(assetBundlePath);

    //    AssetBundleRequest assetLoadRequest = assetBundle.LoadAssetAsync<GameObject>(assetName);
    //    yield return assetLoadRequest;

    //    if (assetLoadRequest != null)
    //    {

    //    }

    //}
}
