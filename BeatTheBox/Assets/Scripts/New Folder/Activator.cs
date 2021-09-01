using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activator : MonoBehaviour {

    public GameObject line;
    public KeyCode key; // 입력 버튼
    public GameObject n; // createMode에서 생성될 노트

    private bool isActive = false; // 판정선에 닿았는지 체크
    public GameObject note; // 노트

     private Transform pos;
    public float ypos;
    public float distance;

    public float buff = 1f;
    public float damageBuff = 1f;
    public float healBuff = 1f;
    

    private bool isAttack = false;

    public static int perNum;
    public static int greNum;
    public static int gooNum;
    public static int badNum;
    public static int misNum;
    public static float rate;

    public void Awake(){
        perNum = 0;
        greNum = 0;
        gooNum = 0;
        badNum = 0;
        misNum = 0;
        rate = 0f;
    }
	public void Update () {

        if (GameManager.instance.createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                line.SetActive(true);
            }

            if (Input.GetKeyUp(key))
            {
                line.SetActive(false);
            }

            if (Input.GetKeyDown(key) && isActive)
            {
                Evaluate();
                Destroy(note);
                rateCal();
                GameManager.instance.animator.SetBool("isAttack", isAttack);
                isActive = false;
                GameManager.instance.UIUpdate();
            }

           
        }
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        isActive = true;

        if (other.gameObject.tag == "Note")
        {
            note = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isActive = false;
    }
    private void Evaluate()
    {
        ypos = note.GetComponent<Transform>().position.y;
        distance = Mathf.Abs(ypos - (-0.84f));

        if(GameManager.instance.Activefriend3 == true){
            buff = 1.5f;
        }
        if(GameManager.instance.Activefriend1 == true){
            damageBuff = 0.7f;
        }
        if(GameManager.instance.Activefriend2 == true){
            healBuff = 1.1f;
        }
        if(distance < 0.15f){
            // perpect
            GameManager.instance.value = -0.05f * healBuff;
            GameManager.instance.playerHp(GameManager.instance.value);
            GameManager.instance.Damage(0.0043f * buff);
            GameManager.instance.combo += 1;
            perNum++;
            isAttack = true;
        }else if (distance < 0.18f){
            // great
            GameManager.instance.value = -0.03f * healBuff;
            GameManager.instance.playerHp(GameManager.instance.value);
            GameManager.instance.Damage(0.0023f * buff);
            GameManager.instance.combo += 1;
            greNum++;
            isAttack = true;
        }else if (distance < 0.21f){
            // good
            GameManager.instance.value = 0;
            GameManager.instance.Damage(0.0013f * buff);
            GameManager.instance.playerHp(GameManager.instance.value);
            GameManager.instance.combo += 1;
            gooNum++;
            isAttack = true;
        }else if(distance < 0.24f){
            // bad
            GameManager.instance.value = 0.05f * damageBuff;
            GameManager.instance.playerHp(GameManager.instance.value);
            GameManager.instance.ResetCombo();
            badNum++;
            isAttack = false;
        }else if (distance >= 0.3f){
            // miss
            GameManager.instance.value = 0.1f * damageBuff;
            GameManager.instance.playerHp(GameManager.instance.value);
            GameManager.instance.ResetCombo();
            misNum++;
            isAttack = false;
        }
    }

    public void rateCal(){
        int noteAll = perNum + greNum + gooNum + badNum + misNum;
        rate = (perNum + 0.8f * greNum + 0.5f * gooNum + 0.3f * badNum + 0f * misNum) / noteAll * 100;
    }
}
