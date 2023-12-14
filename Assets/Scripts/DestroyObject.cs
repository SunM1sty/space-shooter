using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float startTime;
    public float endTime;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        startTime += 0.1f * Time.deltaTime;
        if(startTime >= endTime)
        {
            Destroy(gameObject);
        }
    }
}
