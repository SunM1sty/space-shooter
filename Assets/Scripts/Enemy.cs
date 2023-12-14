using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;
    
    private int _currentHealth;
    private void Start()
    {
        _currentHealth = 2;
    }

    public int CurrentHealth => _currentHealth;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        var player = hitInfo.GetComponent<PlayerController>();
        player?.TakeDamage(1);
    }
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth == 0)
        { 
            Die();
        }
    }
    private void Die()
    {
        _gameManager.IncreaseScore();
        Destroy(gameObject);
    }
}

