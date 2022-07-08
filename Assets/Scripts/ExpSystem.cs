
using UnityEngine;
using UnityEngine.UI;
public class ExpSystem : MonoBehaviour
{
    
    public Sprite[] upgradeImage;
    public Image thisImage;
    public int n;


    public ExpSystem[] expSystem;
    public PlayerController playerController;
    public Health playerHealth;
    public HealthBar healthBar;
    public Bullet bullet;
    public float speed = 5f,health=10f,bulletspeed=10f,bulletDistance=5f;
    public void Start()
    {
        bullet.bulletSpeed = 10f;
        bullet.maxDistance = 7f;
        bullet.poison = false;
        bullet.poisonDamage = 1f;
        bullet.explosionUpgrade = false;
        bullet.damage = 10f;
        bullet.explosionRadius = 1f;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthBar = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<HealthBar>();
        
    }

    public void UpgradeGenerater()
    {
        gameObject.SetActive(true);
        n = Random.Range(0, upgradeImage.Length);
        thisImage.sprite = upgradeImage[n];
    }
    public void UpgradeSelector()
    {
        foreach (ExpSystem expSystem in expSystem)
        {
            expSystem.gameObject.SetActive(false);
        }
        
        switch (n)
        {
            case 0:
                {
                    playerController.speed += speed;
                }
                break;
            case 1:
                {
                    playerHealth.maxHealth += health;
                    playerHealth.currentHealth += health;
                    healthBar.SetMaxHealth(playerHealth.maxHealth);
                    healthBar.SetHealth(playerHealth.currentHealth);
                }
                break;
            case 2:
                {
                    bullet.bulletSpeed += bulletspeed;
                }
                break;
            case 3:
                {
                    if (playerController.bulletnum < 7 )
                    {
                        playerController.bulletnum++;
                    }
                    else
                    {
                        bullet.damage++;
                    }
                }
                break;
            case 4:
                {
                    bullet.maxDistance += bulletDistance;
                }
                break;
            case 5:
                {
                    playerController.recoil = 0f;
                }
                break;
            case 6:
                {
                    playerController.fireRate -= 0.1f;
                }
                break;
            case 7:
                {
                    bullet.poison = true; 
                    bullet.poisonDamage += 0.1f;
                }
                break;
            case 8:
                {
                    bullet.explosionUpgrade = true;
                    bullet.damage++;
                    if (bullet.explosionRadius < 5)
                    {
                        bullet.explosionRadius++;
                    }
                    else
                    {
                        bullet.damage++;
                    }
                }
                break;
        }
        
    }
}
