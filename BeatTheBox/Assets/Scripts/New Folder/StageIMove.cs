using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageIMove : MonoBehaviour {


    private void SceneStart(){
        SceneManager.LoadScene("InGame");
    }
	// Use this for initialization
	public void ButtonClick(){
       Invoke("SceneStart" ,3);
    }

}
