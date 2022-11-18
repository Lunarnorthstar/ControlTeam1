using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDespawn : MonoBehaviour
{
    public float lifetime = 20;

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
