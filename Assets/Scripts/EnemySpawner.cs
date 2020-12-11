using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemyPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemy = (GameObject)Instantiate(enemyPrefabs[randomIndex], transform.position, transform.rotation);
        References.enemies.Add(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
