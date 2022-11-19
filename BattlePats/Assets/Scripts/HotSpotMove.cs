using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HotSpotMove : MonoBehaviour
{
    public float panRadius = 10;
    public float moveTimerMin = 20;
    public float moveTimerMax = 30;
    private float timer = 0;

    private void Start()
    {
        timer = Random.Range(moveTimerMin, moveTimerMax);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            gameObject.transform.position = new Vector3(Random.Range(-panRadius, panRadius), 0.53f,
                Random.Range(-panRadius, panRadius));
            timer = Random.Range(moveTimerMin, moveTimerMax);
        }
    }
}
