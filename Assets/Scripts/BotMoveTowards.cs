using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotMoveTowards : MonoBehaviour
{
    public float EnemySpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate((-1)*transform.up* EnemySpeed * Time.deltaTime);
    }
}
