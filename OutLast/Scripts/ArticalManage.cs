using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KeyType{
	goldKey1,
	goldKey2,
	goldKey3,
	goldKey4,
	goldKey5
}

public class ArticalManage : MonoBehaviour {
//	private static ArticalManage _instance;
//
//	public static ArticalManage Instance{
//		get{ 
//			return _instance;
//		}
//	}

	private bool isEnter = false;

	public KeyType keyType;
	public GameObject gameObj;
	public GameObject gameObj1;

	public static bool image_F = false;

//	void Awake () {
////		_instance = this;
//	}

	void Update () {
		if(isEnter){
			if(Input.GetKeyDown(KeyCode.F)){
				image_F = false;
				if(keyType == KeyType.goldKey1){
					gameObj.SetActive (true);
					gameObj1.SetActive (true);
					GameObject.FindWithTag ("Door1").GetComponent<OpenDoors> ().isOpen = true;
				}
				if(keyType == KeyType.goldKey2){
					gameObj.SetActive (true);
					GameObject.FindWithTag ("Door2").GetComponent<OpenDoors> ().isOpen = true;
				}
				if(keyType == KeyType.goldKey3){
					gameObj.SetActive (true);
					gameObj1.SetActive (true);
					Destroy (GameObject.FindWithTag ("Male"));
					GameObject.FindWithTag ("Door3").GetComponent<OpenDoors> ().isOpen = true;
				}if(keyType == KeyType.goldKey4){
					gameObj.SetActive (true);
					GameObject[] door4 = GameObject.FindGameObjectsWithTag ("Door4");
					for(int i = 0 ; i < 4 ; i++){
						door4[i].GetComponent<OpenDoors> ().isOpen = true;
					}
				}if(keyType == KeyType.goldKey5){
					gameObj.SetActive (true);
					GameObject.FindWithTag ("Door5").GetComponent<OpenDoors> ().isOpen = true;
				}


				this.gameObject.SetActive (false);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			isEnter = true;
			image_F = true;
		}
	}
	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player"){
			isEnter = false;
		}
	}
}