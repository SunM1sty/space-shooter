using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    
    public float speed;
    private float health = 1f;
    private int currentHealth = 1;

    private bool isDead = false;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // ����� �� ������� �� ����������� ���� ����������:
    private void Update()

    {
        if (isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDead = false;
                currentHealth = 1;
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
                _gameManager.StartGame();
            }
        }
        else
        {
            Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * speed;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            isDead = Die();
        }
    }
    bool Die()
    {
        //pause
        Time.timeScale = 0;
        _gameManager.GameOver();

        return true;
        //Destroy(gameObject);
        
    }
}

