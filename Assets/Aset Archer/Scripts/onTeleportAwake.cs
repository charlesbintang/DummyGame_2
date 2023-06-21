using System.Collections;
using UnityEngine;

public class onTeleportAwake : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine("AnotherTeleportActivated");
    }

    IEnumerator AnotherTeleportActivated()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("TowerTeleportation2and3").SetActive(true);
        yield return new WaitForSeconds(0.001f);
        GameObject.Find("TowerTeleportation3and1").SetActive(true);
    }
}
