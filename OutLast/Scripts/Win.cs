using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class Win : MonoBehaviour {

	public PlayableDirector win;
	public Text winText;

	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			col.gameObject.SetActive (false);
			win.Play ();
			winText.text = "恭喜你逃生成功！\n\n\n\n\n\n\n\t\t\t\t（未完待续）";
			col.GetComponent<PlayerManager>().MainCameraCloseShader ();
			StartCoroutine (Wait ());
		}
	}
	IEnumerator Wait(){
		yield return new WaitForSeconds (5.5f);
		OpenPaper.image_Paper = true;
		OpenPaper.final_win = true;
	}
}
