using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);
            SceneManager.LoadScene(1);
        /*if we have multiple scenes for levels then use this line
        SceneManager.LoadScene(SceneManager.GetActiveScene().BuildIndex + 1);*/


        }
    }
}
