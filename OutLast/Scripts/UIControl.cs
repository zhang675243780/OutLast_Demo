using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class UIControl : MonoBehaviour {
		
	public static bool isLoad = false;

	public Text text;

	void Start(){
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Time.timeScale = 1;
	}

	public void GameQuit(){
		Application.Quit ();
	}

	public void GameScene(){
		//保存需要加载的目标场景  
		Globe.nextSceneName = "Scene";  

		SceneManager.LoadScene("Loading");
	}
	public void LoadScene(){
		StartCoroutine (LoadOfSaveScene());
	}
	IEnumerator LoadOfSaveScene(){
		string path = Application.dataPath + "/SaveByJson.json";
		if (File.Exists (path)) {
			isLoad = true;
			Globe.nextSceneName = "Scene";  

			SceneManager.LoadScene("Loading");  
		} else {
			text.text = "你还没有回忆！";
			yield return new WaitForSeconds (1f);
			text.text = ""; 
		}

	}
}
