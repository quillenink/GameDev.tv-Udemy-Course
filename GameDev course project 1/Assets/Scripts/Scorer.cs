using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Scorer : MonoBehaviour
{
    public int score = 10;
    public TMP_Text scoreText;

    private void Start() 
    {
        scoreText.text = "" + score;
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.tag != "Hit" && other.gameObject.GetComponent<ObjectHit>() != null)
        {
            score--;
            scoreText.text = "" + score;
            if(score <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
