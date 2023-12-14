using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLazerMove : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 1;
    public static int enemyLazerCount;

    public float yLowBorder = -5.4f;
    // Start is called before the first frame update
    void Start()
    {
        ++enemyLazerCount;
        rb.velocity = (-1)*transform.up * speed; // �����, ����� ����
    }

    void Update()
    {
        if (transform.position.y < yLowBorder)
        {
            --enemyLazerCount;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name); // ������� � ���� ������
        PlayerController player = hitInfo.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(damage);
            --enemyLazerCount;
            Destroy(gameObject);
        }

        // ���� ���������, ��� ����� ����� �� �������, �������� ����� ����� � �� ����������� ��� ��������
        // ���������� �����
        // UPD: ���, �����, ������ ��������� ��� ������ �� �������
    }
}
