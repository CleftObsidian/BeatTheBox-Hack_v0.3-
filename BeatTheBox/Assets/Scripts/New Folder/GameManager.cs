using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance; // 싱글톤을 할당할 전역 변수
	public bool isGameover = false; // 게임 오버 상태
    public bool isEnd = false;
	public Text DieUI;
    public Text ClearUI; // 게임 오버시 활성화 할 UI 게임 오브젝트
	public Slider EnemyHp;
    public Text comboText;
    public bool createMode;
    public Slider PlayerHP;
    public Animator animator;
    public Animator Enemy; // 사용할 애니메이터 컴포넌트
    public bool isDead = true; 
    public int combo ;
    public float value ;
    public AudioSource Faded;

    
	public bool Activefriend1 = false;
    public bool Activefriend2 = false;
    public bool Activefriend3 = false;
    public void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }


	void Start () {
        combo = 0;
        comboText.text = combo + "";
        PlayerHP.value = 1;
        EnemyHp.value = 1;
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        ResetCombo();
    }

    public void ResetCombo()
    {
        combo = 0;
        UIUpdate();
        Activator.misNum++;
    }

    public void UIUpdate()
    {
        comboText.text = combo + "";
    }
	
	public void Update () {
        if (!isGameover && PlayerHP.value <= 0.00001f){
            DieUI.gameObject.SetActive(true);
            animator.SetTrigger("YouDied");
            Faded.Stop();
            isGameover = true ;
            Activator.rate = 0;
            animator.SetBool("isGameover", isGameover);
            Invoke("GotoResult", 2);
        } else if (isEnd == true){
            ClearUI.gameObject.SetActive(true);
            isGameover = true ;
            Enemy.SetBool("isEnd", isEnd);
            Invoke("GotoResult", 2);
        }
        if(isGameover) return;
        Clear();
    }

    public void Damage(float damage) {
        if(!isGameover){
			EnemyHp.value -= damage;

        }
    }
    public void playerHp(float myValue){
        if(!isGameover){
            PlayerHP.value -=  myValue;
        }
    }
    public void GotoResult(){
        SceneManager.LoadScene("Result");
    }
    public void Clear(){
        if(Faded.isPlaying == false){
            isEnd = true;
        }
    }
}
