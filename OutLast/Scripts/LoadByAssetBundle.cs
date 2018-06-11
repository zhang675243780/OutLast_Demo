using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadByAssetBundle : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync ("AssetBundles/prefabs.unity3d");
		AssetBundle ab = request.assetBundle;
		yield return request;

//		AssetBundleRequest request1 = ab.LoadAllAssetsAsync ();
//		Object[] objs = request1.allAssets;
//		yield return request1;

		Object[] objs = ab.LoadAllAssets ();

				foreach(GameObject o in objs){
					Instantiate (o);
				} 

//		AssetBundle ab = AssetBundle.LoadFromFile("AssetBundles/prefabs.unity3d");
//		Object[] objs = ab.LoadAllAssets ();
//		foreach (GameObject o in objs) {
//			Instantiate (o);
//		}


	}
	

}
