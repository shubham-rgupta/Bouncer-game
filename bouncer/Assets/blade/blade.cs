using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    Vector3 characterScale;
    float characterScaleX;
    public bool Left;
    private float speed = 7f;
    
    void Start()
    {
        characterScale = transform.localScale;
        characterScaleX = characterScale.x;
    }
    void Update()
    {
        if(Left){
            characterScale.x = -characterScaleX;
            transform.Translate(2* speed * Time.deltaTime, 0f, 0f);
        }
        else{
            characterScale.x = characterScaleX;
            transform.Translate(-2* speed * Time.deltaTime, 0f, 0f);
        }
        transform.localScale = characterScale;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("turn"))
        {
            if(Left == true)
            {
                Left = false;
            }
            else{
                Left = true;
            }
        
        }
    }
}
