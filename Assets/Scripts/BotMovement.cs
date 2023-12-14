using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMovement : MonoBehaviour
{
    public float enemySpeed = 1;
    private float xCurr, yCurr;
    private float xNext, yNext;
    private float xMax = 2.5f, yMax = 4.5f;
    private float xMin = -2.5f, yMin = -1.5f;

    private Vector3 posNext;
    // Start is called before the first frame update
    void Start()
    {
        xNext = Random.Range(xMin, xMax);
        yNext = Random.Range(yMin, yMax);
        transform.position = new Vector3(xNext,yNext, 0);
        posNext = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //print("Fixxedd\n");
        if (transform.position == posNext)
        {
            xNext = Random.Range(xMin, xMax);
            yNext = Random.Range(yMin, yMax);
            posNext = new Vector3(xNext, yNext, 0);
        }

        transform.position = Vector3.MoveTowards(transform.position, posNext, Time.deltaTime * enemySpeed);
    }
}
