using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl_game : MonoBehaviour {
	public static UIControl_game _instance;

	public static bool clipOpen = false;

	public GameObject panel;
	public GameObject text_news;
	public GameObject image_f;
	public GameObject image_key;
	public GameObject image_die;
	public GameObject image_paper;
	public Animator animator;

	public GameObject head;
	public Animator image1;
	public Animator image2;

	public AudioClip autoDoorClip;
	public GameObject autoDoor;

	public bool m_cursorIsLocked = false;
	private float timer = 0f;

	public bool image_Paper_Start = true;

	void Awake(){
		_instance = this;
		OpenDoors.image_F = false;
		ArticalManage.image_F = false;
		OpenPaper.image_F = false;
		OpenTrash.image_F = false;
		OpenCabinet.image_F = false;
		OpenDoors.image_Key = false;

		PlayerManager.isDeath = false;
		OpenPaper.final_win = false;
	}

	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape) && m_cursorIsLocked)
		{
			panel.SetActive (true);
			Time.timeScale = 0;
			m_cursorIsLocked = false;
		}
		else if (Input.GetKeyUp(KeyCode.Escape) && !m_cursorIsLocked)
		{
			Time.timeScale = 1;
			m_cursorIsLocked = true;
			panel.SetActive (false);
		}

		if (m_cursorIsLocked) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		} else if (!m_cursorIsLocked) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}

		if(image_paper.active && !panel.active){
			m_cursorIsLocked = false;
			Time.timeScale = 0;
			animator.updateMode = AnimatorUpdateMode.UnscaledTime;
		}else if(!image_paper.active && !panel.active){
			m_cursorIsLocked = true;
			Time.timeScale = 1;
		}

		if (panel.active == true) {
			image_f.SetActive (false);
			image_key.SetActive (false);
			image_paper.SetActive (false);
		} else {
			if (OpenDoors.image_F || ArticalManage.image_F || OpenPaper.image_F || OpenTrash.image_F || OpenCabinet.image_F) {
				image_f.SetActive (true);
				image_key.SetActive (false);
			} else {
				image_f.SetActive (false);
			}


			if (OpenDoors.image_Key) {
				image_f.SetActive (false);
				image_key.SetActive (true);
			} else {
				image_key.SetActive (false);
			}

			if (OpenPaper.image_Paper && !image_Paper_Start) {
				image_f.SetActive (false);
				image_paper.SetActive (true);
			} else if(!OpenPaper.image_Paper && !image_Paper_Start) {
				image_paper.SetActive (false);
			}
		}

		if(text_news.active){
			timer += Time.deltaTime;
			if(timer > 1f){
				text_news.SetActive (false);
				timer = 0f;
			}
		}
			
		if(clipOpen){	
		if(autoDoor.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DoorOpen")){
			autoDoor.GetComponent<AudioSource>().GetComponent<AudioSource> ().PlayOneShot (autoDoorClip,1.2f);
				clipOpen = false;
		}
		}


	}

	public void GoToGame(){
		Time.timeScale = 1;
		m_cursorIsLocked = true;
		panel.SetActive (false);
	}
	public void GoToMenu(){
		SceneManager.LoadScene("Menu");   
	}
	public void GameQuit(){
		Application.Quit ();
	}

	public void ClosePaper(){
		OpenPaper.image_Paper = false;
		image_Paper_Start = false;
	}

	public void FinalWin(){
		if(OpenPaper.final_win){
			SceneManager.LoadScene("Menu");  
		}
	}
}
