using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float minObstacleCooldown = 30;
    public float maxObstacleCooldown = 60;
    [SerializeField] private float spawnTimer = 0;
    
    [Space]
    public int minObjectCount = 1;
    public int maxObjectCount = 3;

    public GameObject[] obstaclePrefabs;

    public float panRadius = 12;
    
    
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(minObstacleCooldown, maxObstacleCooldown);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0)
        {
            SpawnObstacles(Random.Range(minObjectCount, maxObjectCount));
            spawnTimer = Random.Range(minObstacleCooldown, maxObstacleCooldown);
        }
    }

    private void SpawnObstacles(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int type = Random.Range(0, obstaclePrefabs.Length);
            
            switch (type)
            {
                case 0:
                    Instantiate(obstaclePrefabs[type],
                        new Vector3(Random.Range(-panRadius, panRadius), 0, Random.Range(-panRadius, panRadius)),
                        Quaternion.identity);
                    break;
                case 1: Instantiate(obstaclePrefabs[type],
                    new Vector3(Random.Range(-panRadius, panRadius), -40, Random.Range(-panRadius, panRadius)),
                    Quaternion.identity);
                    break;
                case 2: Instantiate(obstaclePrefabs[type],
                    new Vector3(Random.Range(-panRadius, panRadius), 10, Random.Range(-panRadius, panRadius)),
                    new Quaternion(90, 0, 0, 0));
                    break;
                case 3: Instantiate(obstaclePrefabs[type],
                    new Vector3(Random.Range(-panRadius, panRadius), 10, Random.Range(-panRadius, panRadius)),
                    Quaternion.identity);
                    break;
                default: break;
            }
        }
    }
}
