using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner1 : MonoBehaviour
{
    public GameObject Box;
    public Transform Spawner;

    public float timeToSpawn = 10;


    private void Start()
    {

    }


    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Box") == null)
        {
            Debug.Log("Not here!");
            StartCoroutine("Spawn");
        }
        else if (GameObject.FindGameObjectWithTag("Box") != null)
        {
            Debug.Log("It's here!");
            StopCoroutine("Spawn");
        }
    }


    private IEnumerator Spawn()
    {
        Instantiate(Box, Spawner.transform.position, Spawner.transform.rotation);
        yield break;
    }
}
