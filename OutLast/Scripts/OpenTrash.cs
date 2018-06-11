using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrash : MonoBehaviour {
	public static bool image_F = false;
	private Animator animator;
	private bool open=false;

	void Awake(){
		animator = gameObject.GetComponent<Animator> ();
	}
	void Update(){
		if(open){
			image_F = true;
		if (Input.GetKeyDown (KeyCode.F)) {
			if(animator.GetCurrentAnimatorStateInfo (0).IsName ("TrashIdle") || animator.GetCurrentAnimatorStateInfo (0).IsName ("TrashClose")){
				animator.SetBool ("Open", true);
			}
			if(animator.GetCurrentAnimatorStateInfo (0).IsName ("TrashOpen")){
				animator.SetBool ("Open", false);
			}
			}
		}
	}
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player"){
			open = true;
			//Debug.Log ("1");
		}
	}
	void OnTriggerStay(Collider col) {
		if(col.tag == "Player"){
			open = true;
		}
	}
	void OnTriggerExit(Collider col) {
		if(col.tag == "Player"){
			open = false;
			image_F = false;
		}
	}
}