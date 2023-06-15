using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FirstWave : MonoBehaviour
{
    public float countdownTime = 10f; // Waktu countdown dalam detik
    public Text countdownText; // Referensi ke teks yang akan menampilkan countdown
    public GameObject WaveSpawner1;
    public GameObject WaveSpawner2;
    private float currentTime;

    private void Start()
    {
        currentTime = countdownTime;
    }

    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            countdownText.text = currentTime.ToString("0");
        }
        else
        {
            // Countdown selesai, lakukan tindakan yang diinginkan
            StartCoroutine("TurnOffThisScript");
        }
    }

    IEnumerator TurnOffThisScript()
    {
        countdownText.color = Color.red;
        countdownText.text = "Incoming Enemy!";
        yield return new WaitForSeconds(0.001f);
        WaveSpawner1.SetActive(true);
        yield return new WaitForSeconds(0.001f);
        WaveSpawner2.SetActive(true);
        yield return new WaitForSeconds(5f);
        countdownText.enabled = false;
    }
}