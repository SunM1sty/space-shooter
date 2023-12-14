using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerMove : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 1;

    public float yUpBorder = 5f;

    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    void Update()
    {
        if (transform.position.y > 5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name); // выводит в кого попали
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
