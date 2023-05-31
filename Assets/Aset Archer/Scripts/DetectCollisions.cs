using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private Collider colliderToDestroy;

    public float damageValue = 10;
    // Start is called before the first frame update
    void Start()
    {
        colliderToDestroy = gameObject.GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0.1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            enemy.GetComponent<HealthController>().ApplyDamage(damageValue);
            Destroy(gameObject);
        }
        
        if (enemy.gameObject.CompareTag("Arrow"))
        {
            //Destroy(colliderToDestroy.gameObject);
            colliderToDestroy.enabled = false;
        }
    }
}
