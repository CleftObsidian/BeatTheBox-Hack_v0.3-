using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.instance.createMode)
        {
            GameManager.instance.value = 0.1f;
            GameManager.instance.playerHp(GameManager.instance.value);
            Destroy(other.gameObject);
            GameManager.instance.ResetCombo();
        }
    }
}
