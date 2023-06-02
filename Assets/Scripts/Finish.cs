using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishSE;

    private bool levelComplete = false;

    // Start is called before the first frame update
    private void Start()
    {
        finishSE = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && !levelComplete)
        {
            finishSE.Play();
            levelComplete = true;

            Invoke("CompteleLevel", 2f); // deylay 2f
          //  CompteleLevel();

        }
    }

    private void CompteleLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
