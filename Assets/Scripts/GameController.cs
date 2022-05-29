using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public static GameController gameController;
    public GameObject slimePrefab;
    public GameObject turtleShellPrefab;
    public Scrollbar scrollHP;
    public Text scoreText;
    public Transform player;
    
    private float readySecond = 1.0f;
    private float repeatSecond = 0.1f;
    private int hp = 10000;
    private float totalHP = 10000.0f;
    private int damage = 10;
    private double score;
    public int mobCount;

    void Start()
    {
        score = 0;
        mobCount = 0;
        InvokeRepeating("SlimeCreate", readySecond, repeatSecond);
        InvokeRepeating("TurtleShellCreate", readySecond, repeatSecond);
    }

    void Update()
    {
        gameController = this;

        statusUpdate();
        
        scrollHP.size = hp / totalHP;
        
        scoreText.text = "점수 : " + Convert.ToInt64(score);

        if (score > 10000)
        {
            PlayerPrefs.SetString("score", Convert.ToInt32(score).ToString());
            SceneManager.LoadScene("ClearScene");
        }

        if (hp <= 0 || player.position.y < -1)
        {
            PlayerPrefs.SetString("score", Convert.ToInt32(score).ToString());
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void statusUpdate()
    {
        if (score >= 500)
        {
            score += 1.5;
            damage = 20;
        }
        else if (score >= 1000)
        {
            score += 1.7;
            damage = 40;
        }
        else if (score >= 3000)
        {
            score += 2.0;
            damage = 60;
        }
        else if (score >= 5000)
        {
            score += 2.5;
            damage = 80;
        }
        else if (score >= 7000)
        {
            score += 3.0;
            damage = 100;
        }
        else
        {
            score += 1.0;
        }
    }

    void SlimeCreate()
    {
        float posX = Random.Range(0f, 100.0f);
        float posZ = Random.Range(0f, 100.0f);

        if (mobCount <= 500)
        {
            GameObject slime = Instantiate(slimePrefab, new Vector3(posX, 0, posZ), Quaternion.identity);
            mobCount++;
        }
    }

    void TurtleShellCreate()
    {
        float posX = Random.Range(0f, 100.0f);
        float posZ = Random.Range(0f, 100.0f);

        if (mobCount <= 500)
        {
            GameObject turtleShell = Instantiate(turtleShellPrefab, new Vector3(posX, 0, posZ), Quaternion.identity);
            mobCount++;
        }
    }
    
    public void playerDamage()
    {
        hp -= damage;
    }
}
