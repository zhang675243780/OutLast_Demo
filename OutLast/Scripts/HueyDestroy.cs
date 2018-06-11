using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HueyDestroy : MonoBehaviour {

	private float time = 0f;
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time>=10f){
			this.gameObject.SetActive (false);
		}
	}
}
