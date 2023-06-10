using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    public Text ScoreText;
    public int score = 0;
    public int maxScore;
    public int SkorCetbang1;
    public int SkorCetbang2;
    public GameObject Victory;
    public GameObject GameOver;
    public GameObject Cetbang1;
    public GameObject Cetbang2;



    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void AddScore(int newScore)
    {
        score += newScore;
    }

    public void UpdateScore()
    {
        ScoreText.text = "Score: " + score;
    }

    public void YouLose()
    {
        GameOver.SetActive(true);
    }

    public void Cetbang1_Actived()
    {
        Cetbang1.GetComponent<SpawnManager>().enabled = true;
    }

    public void Cetbang2_Actived()
    {
        Cetbang2.GetComponent<SpawnManager>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();

        if (score == maxScore)
        {
            Victory.SetActive(true);
        }
        if (score == SkorCetbang1)
        {
            Cetbang1_Actived();
        }
        if (score == SkorCetbang2)
        {
            Cetbang2_Actived();
        }
    }
}
