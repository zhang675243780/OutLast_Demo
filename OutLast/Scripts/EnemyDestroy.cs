using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
				Destroy(GameObject.FindGameObjectWithTag("Male"));
			this.gameObject.SetActive (false);
		}
	}
}
