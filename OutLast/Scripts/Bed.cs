using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour {

	public Animator animator;
	private BoxCollider boxCollider;
	private bool isIn = false;

	void Awake(){
		boxCollider = this.gameObject.GetComponent<BoxCollider> ();
		animator = GameObject.FindWithTag ("Player").GetComponent<Animator> ();
	}

	void Update(){
		if(isIn){
			if (animator.GetCurrentAnimatorStateInfo (0).IsTag ("Prone")) {
				boxCollider.enabled = false;
			} else {
				boxCollider.enabled = true;
			}
		}
		//boxCollider.enabled = true;
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			isIn = true;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Player"){
			isIn = false;
		}
	}
}
