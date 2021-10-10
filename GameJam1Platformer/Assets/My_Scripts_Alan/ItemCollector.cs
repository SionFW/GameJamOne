using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemCollector2 : MonoBehaviour
{
    private int Apples = 0;

    [SerializeField] private Text ApplesText;

    [SerializeField] private AudioSource collectingSoundEffect;

    // Keeping count of what collectable you have picked up and desrtoying it when collided with.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectingSoundEffect.Play();
            Destroy(collision.gameObject);
            Apples++;
            ApplesText.text ="Apples: " + Apples;

        }
    }
}
