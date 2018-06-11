using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {
	
	private bool isEnter = false;
	private GameObject text;

	void Awake () {
		text = GameObject.Find("Canvas").transform.Find("Text_news").gameObject;
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(!isEnter){
				this.gameObject.SetActive(false);
//				ES2AutoSaveManager mgr = GameObject.Find("ES2 Auto Save Manager").GetComponent<ES2AutoSaveManager>();
//				mgr.Save ();
				SaveJson._instance.SaveByJson();
				text.SetActive(true);
				isEnter = true;
			}
		}
	}
}
