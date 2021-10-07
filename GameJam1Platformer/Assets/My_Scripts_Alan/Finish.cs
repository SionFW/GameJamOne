using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;

    private bool LevelCompleted = false;


    // Start is called before the first frame update
    private void Start()
    {
       
        finishSound = GetComponent<AudioSource>();

    }

    //Play finish sound when colliding with the finish flag and level is finsishd

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !LevelCompleted) 
        {
            finishSound.Play();
            LevelCompleted = true;
            Invoke("CompleteLevel", 2f);

        }
    }

    // Load next level 
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }



}


