using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour {

	public int perfNum = 0;
    public int greaNum = 0;
    public int goodNum = 0;
    public int badsNum = 0;
    public int missNum = 0;
    public float rate = 0f;
	public Text perfect ; 
	public Text Good ;
	public Text Great ;
	public Text Bad ;
	public Text Miss ;
	public Text Rank ;
	public Text Accuracy;


	// Use this for initialization
	void Awake () {
		perfNum = Activator.perNum ;
		greaNum = Activator.greNum;
		goodNum = Activator.gooNum;
		badsNum = Activator.badNum;
		missNum = Activator.misNum;
		rate = Activator.rate;

		perfect.text = "Perfect : " + perfNum;
		Great.text = "Great : " + greaNum;
		Good.text = "Good : " + goodNum;
		Bad.text = "Bad : " + badsNum;
		Miss.text = "Miss : " + missNum;
		Accuracy.text = rate + "%";

		if(rate >= 90f){
			Rank.text = "S";
			if(Friends.friend1 == false){
				Friends.friend1 = true;
			}else if(Friends.friend1 == true && Friends.friend2 == false){
				Friends.friend2 = true;
			}else if(Friends.friend1 == true && Friends.friend2 == true && Friends.friend3 == false){
				Friends.friend3 = true;
			}
		} else if (rate >= 80f){
			Rank.text = "A";
		}else if (rate >= 70f){
			Rank.text = "B";
		}else if (rate >= 60f){
			Rank.text = "C";
		}else if (rate < 60f){
			Rank.text = "F";
		}

	}
}
