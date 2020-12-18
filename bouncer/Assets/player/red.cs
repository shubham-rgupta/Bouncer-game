using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class red : MonoBehaviour
{
    // Vector3 characterScale;
    // float characterScaleX;
    public bool Left;
    private float speed = 13f;
    private bool jumping;
    private float jumpf = 35f;
    private int c = 0;

    void Start()
    {
        // characterScale = transform.localScale;
        // characterScaleX = characterScale.x;
    }

    void Update()
    {
        Jump();

        if(Left){
            //characterScale.x = -characterScaleX;
            transform.Translate(speed *Time.deltaTime, 0f, 0f);
        }
        else{
            //characterScale.x = characterScaleX;
            transform.Translate(-speed *Time.deltaTime, 0f, 0f);
        }
        //transform.localScale = characterScale;
    }

    void Jump()
    {
        if ((Input.touchCount > 0) && !jumping){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpf), ForceMode2D.Impulse);
        c++;
        if(c==2){
        jumping = true;}
        }
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("floors"))
        {
            if(other.contacts[0].normal.y > 0){
            jumping = false;
            c=0;
            }
        }
        
        if(other.gameObject.CompareTag("walls"))
        {
            if(Left == true)
            {
                Left = false;
            }
            else{
                Left = true;
            }
        }

        if(other.gameObject.CompareTag("blocks"))
        {
            jumping = false;
            if((other.contacts[0].normal.x < 0 || other.contacts[0].normal.x > 0) && other.contacts[0].normal.y < 0.5){

                if(Left == true)
                {
                Left = false;
                }
                else{
                Left = true;
                }
            }
        }

        if(other.gameObject.CompareTag("spikes")||other.gameObject.CompareTag("blade")){
            Destroy(gameObject);
            SceneManager.LoadScene(0);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("spring")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpf*2f), ForceMode2D.Impulse);
            jumping= true;
        }  
    }
}
