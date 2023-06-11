using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour
{
    public GameObject player;
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public Button buttonTrigger;
    private bool canAttack = true;
    int iteration = 0;
    // public bool hasHit = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (iteration == 3)
        {
            // player.transform.position = new Vector3(xPosition, yPosition, zPosition);
            iteration = 0;
            GoUpToTower();
            Debug.Log("Teleport!");
            // player.transform.localEulerAngles = Vector3.zero;
        }
        // if (Input.GetButtonUp("Fire2"))
        // {
        //     hasHit = false;
        // }
    }

    private void OnTriggerEnter(Collider enemy)
    {
        if (enemy.gameObject.CompareTag("Enemy"))
        {
            if (iteration < 3)
            {
                enemy.GetComponent<HealthController>().ApplyDamage(100);
                iteration += 1;
                // hasHit = true;
            }
        }
    }

    private void GoUpToTower()
    {
        if (canAttack)
        {
            buttonTrigger.onClick.Invoke();
            Debug.Log("Teleported!!");
            // canAttack = false;
        }
    }
}
