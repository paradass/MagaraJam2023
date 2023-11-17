using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnTime;
    public GameObject Enemy;

    void Start()
    {
        InvokeRepeating("Spawn", 0, SpawnTime);
    }

    void Spawn()
    {
        Instantiate(Enemy, transform.position, Quaternion.identity);
    }
}
