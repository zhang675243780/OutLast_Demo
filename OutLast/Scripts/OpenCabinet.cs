using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCabinet : MonoBehaviour {
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
			if(animator.GetCurrentAnimatorStateInfo (0).IsName ("CabinetIdle") || animator.GetCurrentAnimatorStateInfo (0).IsName ("CabinetClose")){
				animator.SetBool ("Open", true);
			}
			if(animator.GetCurrentAnimatorStateInfo (0).IsName ("CabinetOpen")){
				animator.SetBool ("Open", false);
			}
			}
		}
	}
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player"){
			open = true;
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
