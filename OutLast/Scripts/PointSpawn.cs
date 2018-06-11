using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpawn : MonoBehaviour {

	public GameObject Enemy;
	private bool isEnter = false;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			if(!isEnter){
//				ES2AutoSaveManager mgr = GameObject.Find("ES2 Auto Save Manager").GetComponent<ES2AutoSaveManager>();
//				mgr.Save ();
//				Debug.Log (1);
				GameObject.Instantiate (Enemy,this.transform.position,Quaternion.identity);
				isEnter = true;
				this.gameObject.SetActive(false);
			}
		}
	}
}
