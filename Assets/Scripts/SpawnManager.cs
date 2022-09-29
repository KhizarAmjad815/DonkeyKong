using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject barrelPrefab;
    public float minTime = 3f;
    public float maxTime = 6f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnBarrel", 1f, Random.Range(minTime, maxTime));
    }

    void SpawnBarrel()
    {
        Instantiate(barrelPrefab, transform.position, barrelPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
