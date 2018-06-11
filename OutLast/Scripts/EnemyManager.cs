using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using com.ootii.Actors;

public class EnemyManager : MonoBehaviour {
	public static float time = 7f;

	public ActorController player;
	public PlayableDirector death;
	public TimelineAsset timeline;
	private Animator animator;
	private float timer = 0f;

	Dictionary<string, PlayableBinding> bindingDict = new Dictionary<string, PlayableBinding>();
	private Animator gobj1;
	private GameObject gobj2;
	private GameObject gobj3;
	private GameObject gobj4;
	private Animator gobj5;
	private Animator gobj6;

	void Awake(){
		gobj1 = GameObject.FindWithTag ("Player").GetComponent<Animator> ();
		gobj2 = gobj1.gameObject.transform.Find ("Camera").gameObject;
		gobj4 = gobj1.gameObject.transform.Find ("HeadManager").gameObject;
	}

	void Start () {
		animator = GetComponent<Animator> ();
		death = GetComponent<PlayableDirector> ();
		player = GameObject.FindWithTag ("Player").GetComponent<ActorController> ();

		gobj3 = UIControl_game._instance.head;
		gobj5 = UIControl_game._instance.image1;
		gobj6 = UIControl_game._instance.image2;

		foreach (var at in death.playableAsset.outputs) {
			if (!bindingDict.ContainsKey (at.streamName)) {
				bindingDict.Add (at.streamName, at);
			}
		}

	}

	void Update () {

		if (!PlayerManager.isDeath) {
			if (animator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
				PlayerManager.isDeath = true;
				time = 7f;
				IsDeath ();
			}
		} else {
			gobj1.gameObject.GetComponent<PlayerManager> ().MainCameraCloseShader ();
			player.enabled = false;
			timer += Time.deltaTime;
			if(timer > time){
				SceneManager.LoadScene("Menu");  
			}
		}
	}

	public void IsDeath(){
		TimeLineSetValue ();
	}

	public void TimeLineSetValue(){
		death.SetGenericBinding (bindingDict ["Player"].sourceObject, gobj1);
		death.SetGenericBinding (bindingDict ["Camera1"].sourceObject,gobj2);
		death.SetGenericBinding (bindingDict ["Camera2"].sourceObject,gobj2.GetComponent<Animator>());
		death.SetGenericBinding (bindingDict ["HeadF"].sourceObject,gobj3);
		death.SetGenericBinding (bindingDict ["Head1"].sourceObject,gobj4);
		death.SetGenericBinding (bindingDict ["Head2"].sourceObject,gobj4.GetComponent<Animator>());
		death.SetGenericBinding (bindingDict ["Image1"].sourceObject,gobj5);
		death.SetGenericBinding (bindingDict ["Image2"].sourceObject,gobj6);
		death.Play ();
	}
}
