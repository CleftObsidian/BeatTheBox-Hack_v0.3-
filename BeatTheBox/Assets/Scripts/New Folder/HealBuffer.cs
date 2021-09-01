using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealBuffer : MonoBehaviour {

	// Use this for initialization
	public void check(Toggle t){
		if(t.isOn){
			GameManager.instance.Activefriend2 = true;
		}else{
			GameManager.instance.Activefriend2 = false;
		}
	}
}
