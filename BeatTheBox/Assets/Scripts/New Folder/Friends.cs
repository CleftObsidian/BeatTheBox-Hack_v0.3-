using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Friends : MonoBehaviour {
    public GameObject friends ;
    public GameObject friends1 ;
    public GameObject friends2 ;
    public GameObject friends3 ;

    public static bool friend1 = false;
	public static bool friend2 = false;
	public static bool friend3 = false;
    public void ButtonClick(){
            friends.SetActive(true);

            if(friend1 == true){
                friends1.SetActive(true);
            }
            
            if(friend2 == true){
                friends2.SetActive(true);
            }
            
            if(friend3 == true){
                friends3.SetActive(true);
            }
        }
}
