using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FirstWave : MonoBehaviour
{
    public float countdownTime = 10f; // Waktu countdown dalam detik
    public Text countdownText; // Referensi ke teks yang akan menampilkan countdown
    public GameObject WaveSpawner1;
    public GameObject WaveSpawner2;
    public GameObject Wave1;
    public GameObject EnemyComing;
    private float currentTime;
    AudioSource audioSource;
    private bool done = true;

    private void Awake()
    {
        currentTime = countdownTime;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            countdownText.color = Color.red;
            countdownText.text = currentTime.ToString("0");
        }
        else
        {
            // Countdown selesai, lakukan tindakan yang diinginkan
            if (done){
                EnemyComing.SetActive(true);
                StartCoroutine("TurnOffThisScript");
            }
            done = false;
        }
    }

    IEnumerator TurnOffThisScript()
    {
        countdownText.text = " ";
        yield return new WaitForSeconds(0.001f);
        audioSource.enabled = true;
        yield return new WaitForSeconds(0.001f);
        WaveSpawner1.SetActive(true);
        yield return new WaitForSeconds(0.001f);
        WaveSpawner2.SetActive(true);
        yield return new WaitForSeconds(5f);
        EnemyComing.SetActive(false);
        countdownText.enabled = false;
        Wave1.SetActive(false);
    }
}