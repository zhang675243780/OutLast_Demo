using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class SaveJson : MonoBehaviour {
	public static SaveJson _instance;

	public GameObject player;

	public GameObject[] needToSave;
	public OpenDoors[] opendoors;

	public Animator[] doorAnimators;

	public class NeedToSave{
		public double pos_x{ get; set;}
		public double pos_y{ get; set;}
		public double pos_z{ get; set;}

		public double lightTime{ get; set;}

		public bool haveVideo{ get; set;}
		public List<bool> gameObjectsList= new List<bool>();

		public List<bool> doors= new List<bool>();
		public List<bool> doorsAnimator= new List<bool>();
	}

	void Awake(){
		_instance = this;
	}

	public void SaveByJson(){
		NeedToSave game = new NeedToSave ();

		game.pos_x = player.transform.position.x;
		game.pos_y = player.transform.position.y;
		game.pos_z = player.transform.position.z;
		game.lightTime = player.GetComponent<PlayerManager> ().time;
		game.haveVideo = player.GetComponent<PlayerManager> ().haveVideo;

		for(int i = 0;i<needToSave.Length;i++){
			game.gameObjectsList.Add (needToSave[i].active);
		}
		for(int i = 0;i<opendoors.Length;i++){
			game.doors.Add (opendoors[i].isOpen);
		}
		for(int i = 0;i<doorAnimators.Length;i++){
			game.doorsAnimator.Add (doorAnimators[i].GetBool("Open"));
		}

		string json = JsonMapper.ToJson (game);

		string path = Application.dataPath + "/SaveByJson.json";

		StreamWriter sw = new StreamWriter (path);
		sw.Write (json);

		sw.Close ();

	}
		

	public void LoadByJson(){

		string path = Application.dataPath + "/SaveByJson.json";

		StreamReader sr = new StreamReader (path);

		string toJson = sr.ReadLine ();
		sr.Close ();
		NeedToSave newgame = JsonMapper.ToObject<NeedToSave> (toJson);

		player.transform.position = new Vector3 ((float)newgame.pos_x,(float)newgame.pos_y,(float)newgame.pos_z);
		player.GetComponent<PlayerManager> ().time = (float)newgame.lightTime;
		player.GetComponent<PlayerManager> ().haveVideo = newgame.haveVideo;

		for(int i = 0;i<needToSave.Length;i++){
			needToSave [i].SetActive (newgame.gameObjectsList[i]);
		}
		for(int i = 0;i<opendoors.Length;i++){
			opendoors [i].isOpen = newgame.doors [i];
		}
		for(int i = 0;i<doorAnimators.Length;i++){
			doorAnimators [i].SetBool ("Open",newgame.doorsAnimator[i]);
		}

	}
}
