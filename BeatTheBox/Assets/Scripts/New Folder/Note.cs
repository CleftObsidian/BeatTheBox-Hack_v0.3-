using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
    private Rigidbody2D rb;
   
    private float speed = 2f;
    public float xpos ;
    public float ypos ;
    public GameObject note;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (note == null)
        {
            note = this.gameObject;
        }
    }

    void Update () {
        rb.velocity = new Vector2(0, -speed);
        xpos = note.GetComponent<Transform>().position.x;
        ypos = note.GetComponent<Transform>().position.y;
        if(xpos == -7f){
            xpos = -1.417f;
        }else if(xpos == -6f){
            xpos = -1.087f;
        }else if(xpos == -9f){
            xpos = -2.0166f;
        }else if(xpos == -8f){
            xpos = -1.72f;
        }else if(xpos == -5f){
            xpos = -0.788f;
        }else if(xpos == -4f){
            xpos = -0.476f;
        }
        
        note.GetComponent<Transform>().position = new Vector2(xpos, ypos);
    }

   
}