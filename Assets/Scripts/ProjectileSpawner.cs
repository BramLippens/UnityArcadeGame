using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject EnemyBomb;
    private float spawnTimer = 2;
    private float spawnMax = 10;
    private float spawnMin = 5;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnMin, spawnMax);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0)
        {
            Instantiate(EnemyBomb, transform.position, Quaternion.identity);// quaternion is like vector3 for rotations, identity is like no rotation
            spawnTimer = Random.Range(spawnMin, spawnMax);
        }
    }
}
