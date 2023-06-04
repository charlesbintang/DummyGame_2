using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectCollision : MonoBehaviour
{
    public float damageValue = 5;
    // Start is called before the first frame update
    void Start()
    {

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
        }
    }
}
