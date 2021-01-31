using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float duration = 5f;
    private float currentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        Debug.Log(currentTime);

        if (currentTime > duration)
        {
            Debug.Log("Duration reached.");

            currentTime = 0f;
        }
    }
}
