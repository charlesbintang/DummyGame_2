/* HealthController.cs */
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GateHealthController : MonoBehaviour
{
    [SerializeField]
    private GameObject healthPanel;

    [SerializeField]
    private RectTransform healthBar;

    [SerializeField]
    private Text healthText;

    public GameObject[] enemyAsset;

    private float healthBarStartWidth;

    private float currentHealth;

    [SerializeField]
    private float maxHealth;

    [SerializeField]
    private float respawnTime;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        healthBarStartWidth = healthBar.sizeDelta.x;
        ResetHealth();
        UpdateHealthUI();
    }

    public void ApplyDamage(float damage)
    {
        if (isDead) return;

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
            for (int i = 0; i < enemyAsset.Length; i++)
            {
                enemyAsset[i].SetActive(false);
            }
            healthPanel.SetActive(false);
            // Destroy(gameObject);
            // StartCoroutine(RespawnAfterTime());
            // score.AddScore(1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<Scoring>().YouLose();
            StartCoroutine(VideoScene());
            // SceneManager.LoadScene("Menu Start");
        }

        UpdateHealthUI();
    }

    IEnumerator RespawnAfterTime()
    {
        yield return new WaitForSeconds(respawnTime);
        ResetHealth();
    }

    IEnumerator VideoScene()
    {
        yield return new WaitForSeconds(respawnTime);
        SceneManager.LoadScene("JustMainMenu");
    }

    private void ResetHealth()
    {
        isDead = false;
        currentHealth = maxHealth;
        for (int i = 0; i < enemyAsset.Length; i++)
        {
            enemyAsset[i].SetActive(true);
        }
        healthPanel.SetActive(true);
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        float percentOutOf = (currentHealth / maxHealth) * 100;
        float newWidth = (percentOutOf / 100f) * healthBarStartWidth;

        healthBar.sizeDelta = new Vector2(newWidth, healthBar.sizeDelta.y);
        // healthText.text = currentHealth + "";
    }
}