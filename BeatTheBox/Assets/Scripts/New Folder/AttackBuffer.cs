using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AttackBuffer : MonoBehaviour {

	// Use this for initialization
	public void check(Toggle t){
		if(t.isOn){
			GameManager.instance.Activefriend1 = true;
		}else{
			GameManager.instance.Activefriend1 = false;
		}
	}
}
