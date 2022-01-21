using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    public Image healthBar;
    public float Startspeed = 10f;
    public float Starthealth = 100f;
    public float speed;
    public int worth = 50;
    public float health = 100;
    public GameObject deatheffect;
    bool AmDead = false;
    public void TakeDamage(float amount)
    {
        health -= amount;
        healthBar.fillAmount = health / Starthealth;
        if (health <= 0 && !AmDead)
        {
            Die();
        }
    }

    private void Die()
    {
        AmDead = true;
        WaveSpawner.enemiesAlive--;
        playerStats.Money += worth;
        GameObject dieeffect = Instantiate(deatheffect, transform.position, Quaternion.identity);
        Destroy(dieeffect, 5f);
        Destroy(gameObject);

    }
    public void Slow(float amount)
    {
        speed = Startspeed * (1f - amount);
    }
    private void Start()
    {
        speed = Startspeed;
        health = Starthealth;
    }
}