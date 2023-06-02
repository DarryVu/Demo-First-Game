using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int Fruits = 0;
    [SerializeField] private Text fruitsText;
    [SerializeField] private AudioSource collectionSE;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruits"))
        {
            collectionSE.Play();
            Destroy(collision.gameObject);
            Fruits++;
            fruitsText.text = "Fruits:" + Fruits + "/3";
        }
    }
}