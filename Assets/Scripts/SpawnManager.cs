using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obsaclePrefab;

    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2.0f;
    private float repeatingRate = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatingRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(obsaclePrefab, spawnPos, obsaclePrefab.transform.rotation);
    }
}
