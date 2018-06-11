using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OpenDoors: MonoBehaviour {
	
	public bool isOpen = true;

	private Animator animator;
	private bool open=false;

	public static bool image_F = false;
	public static bool image_Key = false;

	void Awake(){
		animator = gameObject.GetComponent<Animator> ();
	}
	void Update(){
		Ray mRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit mHi;

		if (open) {
			if (Physics.Raycast (mRay, out mHi)) {
				if (mHi.collider.gameObject == this.gameObject) {
					if(!image_Key){
						image_F = true;
					}
						if (Input.GetKeyDown (KeyCode.F)) {
						if (isOpen) {
							if (this.gameObject.tag == "AutoDoor") {
								animator.SetTrigger ("Open");
								UIControl_game.clipOpen = true;
							} else {
								if (animator.GetCurrentAnimatorStateInfo (0).IsName ("DoorIdle") || animator.GetCurrentAnimatorStateInfo (0).IsName ("DoorClose")) {
									animator.SetBool ("Open", true);
								}
								if (animator.GetCurrentAnimatorStateInfo (0).IsName ("DoorOpen")) {
									animator.SetBool ("Open", false);
								}
							}
						} else {
							image_Key = true;
							image_F = false;
						}
					}
				} else {
					image_F = false;
				}
			}
		}


	}
	void OnTriggerEnter(Collider col) {
		if(col.tag == "Player"){
			open = true;
		}if(col.tag == "Male" || col.tag == "ActiveMale"){
			if(isOpen){
			if(animator.GetCurrentAnimatorStateInfo (0).IsName ("DoorIdle") || animator.GetCurrentAnimatorStateInfo (0).IsName ("DoorClose")){
				animator.SetBool ("Open", true);
				}
			}
		}
	}
	void OnTriggerExit(Collider col) {
		if(col.tag == "Player"){
			open = false;
			image_F = false;
			image_Key = false;
		}
	}
		
}
