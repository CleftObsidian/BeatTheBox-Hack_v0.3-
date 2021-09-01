using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageIIMove : MonoBehaviour {

	private void SceneStart()
    {
        SceneManager.LoadScene("InGame 2");
    }
    // Use this for initialization
    public void ButtonClick()
    {
        Invoke("SceneStart", 3);
    }
}
