using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPaper : MonoBehaviour {

	public static bool image_F = false;
	public static bool image_Paper = false;
	public static bool final_win = false;

	public  Text text;

	private bool open = false;

	void Update(){
		if(open){
			if(Input.GetKeyDown(KeyCode.F)){
				image_F = false;
				image_Paper = true;
				PaperNumber ();
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.tag == "Player"){
			open = true;
			image_F = true;
		}
	}
	void OnTriggerStay(Collider col){
		if(col.tag == "Player"){
			open = true;
			image_F = true;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.tag == "Player"){
			open = false;
			image_F = false;
		}
	}

	public void PaperNumber(){
		if(this.gameObject.name == "Paper1"){
			text.text = "（好心人的提示）根据许多报道表明，这里的精神病患者非常奇怪。感觉无处不在，又感觉不存在！这个问题让来这里的人都神秘的消失了。你的伙伴是否在你身边？如果不在，请去寻找！这个问题的真实情况无人知晓，希望你能打破这个迷题！但还是请万分小心。<color=#ff0000ff>噢，对了，你的摄像机被人拿走了，先去寻找！</color>（按下E打开摄像机夜视效果,空格键可以爬一些墙）";
		}
		if(this.gameObject.name == "Paper2"){
			text.text = "看到这张纸条，证明你已经迷路了。听说车厂可能会有精神病人的存在，不知道是不是真的，或许你可以去看看，也可能可以找到关于你伙伴消失的线索。(后方冒烟的地方)";
		}
		if(this.gameObject.name == "Paper3"){
			text.text = "啊啊啊啊！这个人果然不一样，非常适合下一步实验的进行。我已经迫不及待等待实验的最终效果了，可是为什么感觉缺了点什么？是还需要一个人吗？难道是那个遗漏的人？啊，不，这是哪，我在干什么？老毛病又犯了吗？不行，我要去睡一会。";
		}
		if(this.gameObject.name == "Paper4"){
			text.text = "我们相信精神病是由于局部性感染所致，所以我们需要一大堆活实验体进行实验，我们需要将实验体获得精神病，哪怕让他在绝望中（拔实验体的指甲，让其长出后继续拔，重复此过程）。实验体有精神病后，我们便可以开始实验，最初我们可以拔牙和切除扁桃体等等，重一些无关紧要的器官开始，随后可以开始移除内脏…哈哈哈";
		}
		if(this.gameObject.name == "Paper5"){
			text.text = "朋友，希望你能看到这封信，这是我中途逃离时，最终知道无法逃脱时写下的，但是当你看到这封信时，可能我已经受到这些村民的疯狂行为！你那么聪明，应该已经知道他们的行为！去阻止他们！报道他们的行为！去大房子！不！他们找到我了，最重要的，其实他们早就在找你了，逃生～逃生～逃...";
		}
		if(this.gameObject.name == "Paper6"){
			text.text = "我们把这里封起来了，他不可能可以逃出去，就算他有我们的实验内容。他也逃不出去。虽然以防万一，我们留了一条生路，但是他一定想象不到，也到不了二楼，放心吧（哈哈哈！不！哈哈哈！@＃~&%）";
		}
		if(this.gameObject.name == "Paper7"){
			text.text = "逃生:这栋楼尽头的木门";
		}
		if(this.gameObject.name == "Paper8"){
			text.text = "前几天屋顶破了个洞口，我还在想怎么补...";
		}
		if(this.gameObject.name == "Paper9"){
			text.text = "对面变态的夫妇竟然把房子围起来了！还好我挖了个洞，等等起床要记得去把洞封住.....";
		}
		if(this.gameObject.name == "Paper10"){
			text.text = "我们把这里封起来了，他不可能可以逃出去，就算他有我们的实验内容。他也逃不出去。虽然以防万一，我们留了一条生路，但是他一定想象不到，也到不了二楼，放心吧（哈哈哈！不！哈哈哈！@＃~&%）";
		}


//		if(this.gameObject.name == "Paper8"){
//			text.text = "恭喜你逃生成功！\n\n\n\n\n\n\n\t\t\t\t（未完待续）";
//			final_win = true;
//		}
	}
}
