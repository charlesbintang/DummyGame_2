using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectCollision : MonoBehaviour
{
    public float damageValue = 5;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider hand)
    {
        if (hand.gameObject.CompareTag("Target"))
        {
            hand.GetComponent<GateHealthController>().ApplyDamage(damageValue);
            StartCoroutine(AudioActivated());
        }
    }

    IEnumerator AudioActivated(){
        audioSource.enabled = true;
        yield return new WaitForSeconds(1f);
        audioSource.enabled = false;
    }
}
