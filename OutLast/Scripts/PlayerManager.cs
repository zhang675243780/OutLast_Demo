using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Colorful;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PlayerManager : MonoBehaviour {
	public static bool isDeath = false;
	public float height = 4f;
	public GameObject light;
	public GameObject mainCamera;

	public Slider slider_Battery;
	public GameObject light_Camera_UI;

	public float time = 30f;
	public PlayableDirector playable;

	private Vector3 pos;
	private Animator animator;

	private float timer = 30f;

	public bool haveVideo = false;

	void Awake(){
		pos.y = this.transform.position.y;
		animator = gameObject.GetComponent<Animator> ();

	}

	void Update(){
		Ray ray = new Ray (this.transform.position + new Vector3(0,-0.8f,0), Vector3.up);
		RaycastHit hitInfo;

		if (Physics.Raycast (ray, out hitInfo)) {
			if (hitInfo.collider.gameObject.tag == "Player") {
				if(animator.GetCurrentAnimatorStateInfo (0).IsName ("JumpToClimb") 
					||animator.GetCurrentAnimatorStateInfo (0).IsName ("LadderUp") || animator.GetCurrentAnimatorStateInfo (0).IsName ("LadderDown")){
					pos.y = this.transform.position.y;
				}
			} else {
				if(pos.y > (transform.position.y + height)){
					playable.Play ();
					EnemyManager.time = 5f;
					isDeath = true;
				}
				pos.y = this.transform.position.y;
			}

		}
		//Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
		if(haveVideo){
		if (light.active) {
			time -= Time.deltaTime;
			slider_Battery.value = time / timer;
			if(Input.GetKeyDown(KeyCode.E)){
				MainCameraCloseShader ();
			}if(time < 0){
				MainCameraCloseShader ();
			}
		}else if(!light.active){
			time += Time.deltaTime * 0.5f;
			if(time > 30f){
				time = 30f;
			}
			if(time >= 0){
			if(Input.GetKeyDown(KeyCode.E)){
					MainCameraOpenShader ();
			}
			}
		}
		}

		if(UIControl.isLoad){
//			ES2AutoSaveManager mgr = GameObject.Find("ES2 Auto Save Manager").GetComponent<ES2AutoSaveManager>();
//			mgr.Load ();
			SaveJson._instance.LoadByJson();
			UIControl_game._instance.m_cursorIsLocked = true;
			UIControl_game._instance.image_Paper_Start = false;
			OpenPaper.image_Paper = false;
			UIControl.isLoad = false;
		}

	}

	public void MainCameraOpenShader(){
		light.SetActive (true);
		light_Camera_UI.SetActive (true);
		mainCamera.GetComponent<AnalogTV> ().enabled = true;
		mainCamera.GetComponent<ContrastVignette> ().enabled  = true;
		mainCamera.GetComponent<Noise> ().enabled = true;
	}

	public void MainCameraCloseShader(){
		light.SetActive (false);
		light_Camera_UI.SetActive (false);
		mainCamera.GetComponent<AnalogTV> ().enabled = false;
		mainCamera.GetComponent<ContrastVignette> ().enabled  = false;
		mainCamera.GetComponent<Noise> ().enabled = false;
	}
		
	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Video") {
			OpenTrash.image_F = true;
			if(Input.GetKeyDown(KeyCode.F)){
				haveVideo = true;
				OpenTrash.image_F = false;
				col.gameObject.SetActive (false);
			}
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.tag == "Video"){
			OpenTrash.image_F = false;
		}
	}

}
