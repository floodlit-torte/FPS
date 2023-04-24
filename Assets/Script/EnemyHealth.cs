using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int _currentHealth;

    private void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= Mathf.Abs(damage);
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
