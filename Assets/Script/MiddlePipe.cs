using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MiddlePipe : MonoBehaviour
{
    private ScoreSystem scoreSystem;

    // Start is called before the first frame update
    void Start()
    {
        scoreSystem = GameObject.FindGameObjectWithTag("ScoreManager")
        .GetComponent<ScoreSystem>();   
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            scoreSystem.AddScore();

    }
}
