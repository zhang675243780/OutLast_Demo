using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour {

	public float timer = 50f;
	public float lowerSpeed = 3f;
	public AudioSource audioSourcePlayer;

	private float time = 0f;
	private AudioSource audioSource;
	private Animator animator;
	//private bool leftS = false;

	// Use this for initialization
	void Awake () {
		audioSource = gameObject.GetComponent<AudioSource> ();
		animator = audioSourcePlayer.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		bool walk = Mathf.Abs (h) > 0 || Mathf.Abs (v) > 0;

		if (walk) {	
			if (animator.GetCurrentAnimatorStateInfo (0).IsTag("Prone")
				|| animator.GetCurrentAnimatorStateInfo (0).IsTag("Sneak")
				||animator.GetCurrentAnimatorStateInfo (0).IsTag ("Ladder")) {
				audioSourcePlayer.enabled = false;
			} else {
				audioSourcePlayer.enabled = true;
				audioSourcePlayer.pitch = 1.0f;
			}
		} else {
			audioSourcePlayer.enabled = false;
		}

		if (Input.GetKey (KeyCode.LeftShift) && walk) {
//			Debug.Log ("1");
			time += Time.deltaTime;
			audioSource.enabled = true;
			audioSource.volume = time / timer;
			audioSourcePlayer.pitch = 1.5f;
		} else {
			if (time <= 0f) {
				audioSource.enabled = false;
				return;
			}
			time -= (Time.deltaTime * lowerSpeed);
			audioSource.volume = time / timer;
		}
			
	}
}
