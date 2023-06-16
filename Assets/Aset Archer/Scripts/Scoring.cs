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
    public int SkorSword;
    public GameObject Victory;
    public GameObject GameOver;
    public GameObject Cetbang1;
    public GameObject Cetbang2;
    public GameObject Sword;
    public Text AnnouncementText;
    private bool notLoop = true;
    public string LoadAScene;



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
        ScoreText.text = "             " + score;
    }

    public void YouLose()
    {
        GameOver.SetActive(true);
    }

    public void YouWin()
    {
        Victory.SetActive(true);
        gameObject.GetComponent<ManagerScene>().LoadToScene(LoadAScene);
    }

    public void Cetbang1_Actived()
    {
        if (notLoop)
        {
            StartCoroutine("ForCetbang1");
            notLoop = false;
        }
        else
        {
            return;
        }
    }
    public void Cetbang2_Actived()
    {
        if (notLoop)
        {
            StartCoroutine("ForCetbang2");
            notLoop = false;
        }
        else
        {
            return;
        }
    }
    public void Sword_Actived()
    {
        if (notLoop)
        {
            StartCoroutine("ForSword");
            notLoop = false;
        }
        else
        {
            return;
        }
    }

    IEnumerator ForCetbang1()
    {
        Cetbang1.GetComponent<SpawnManager>().enabled = true;
        AnnouncementText.text = "East Cetbang is Activated";
        yield return new WaitForSeconds(2f);
        AnnouncementText.text = " ";
    }
    IEnumerator ForCetbang2()
    {
        Cetbang2.GetComponent<SpawnManager>().enabled = true;
        AnnouncementText.text = "West Cetbang is Activated";
        yield return new WaitForSeconds(2f);
        AnnouncementText.text = " ";
    }
    IEnumerator ForSword()
    {
        Sword.SetActive(true);
        AnnouncementText.text = "Ability Sword is unlocked";
        yield return new WaitForSeconds(2f);
        AnnouncementText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();

        if (score == maxScore)
        {
            YouWin();
        }
        if (score == SkorCetbang1)
        {
            Cetbang1_Actived();
        }
        if (score == SkorCetbang1 + 1)
        {
            notLoop = true;
        }
        if (score == SkorCetbang2)
        {
            Cetbang2_Actived();
        }
        if (score == SkorCetbang2 + 1)
        {
            notLoop = true;
        }
        if (score == SkorSword)
        {
            Sword_Actived();
        }
    }
}
