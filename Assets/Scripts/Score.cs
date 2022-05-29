using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "점수 : " + PlayerPrefs.GetString("score", "0");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
