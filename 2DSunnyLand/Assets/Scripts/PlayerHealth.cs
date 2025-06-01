using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthBarFill;
    public GameObject gameOverPanel;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();

        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision detected");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10f);
            //Debug.Log("TAKE DAMAGE");
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }

    void Die()
    {
        //Debug.Log("You died!");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Time.timeScale = 0f;

        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        this.enabled = false;
    }
}