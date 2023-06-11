using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class GoDown : MonoBehaviour
{
    public GameObject playerController;
    [SerializeField] private Transform playerSpawnPosition;
    public float yRotation = 90f;

    // Start is called before the first frame update
    void Awake()
    {
    }

    public void GoDownToEnemy()
    {
        StartCoroutine("Teleporting");
    }

    IEnumerator Teleporting()
    {
        // Vector3 spawnPosition = playerSpawnPosition.position;
        // playerController.SetActive(false);
        playerController.GetComponent<VREmulator>().enabled = false;
        yield return new WaitForSeconds(0.01f);
        gameObject.transform.position = new Vector3(-17.25f, 0, -8.01f);
        gameObject.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);
        yield return new WaitForSeconds(0.01f);
        playerController.GetComponent<VREmulator>().enabled = true;
        // playerController.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
