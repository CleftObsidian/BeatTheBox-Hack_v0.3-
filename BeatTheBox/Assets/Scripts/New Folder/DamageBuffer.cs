using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DamageBuffer : MonoBehaviour {

	// Use this for initialization
	public void check(Toggle t){
		if(t.isOn){
			GameManager.instance.Activefriend3 = true;
		}else{
			GameManager.instance.Activefriend3 = false;
		}
	}
}
