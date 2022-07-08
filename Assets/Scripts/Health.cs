using UnityEngine;
public class Health : MonoBehaviour
{
    public float maxHealth = 3f,currentHealth;
    public GameObject deatheffect;

    public bool invincible = false;
    public float maxInvincibleTime = 1f, currentInvincibleTime;

    public HealthBar healthbar;
    public Score score;
    public ExpBar expbar;

    public Canvas canvas;

    public void Awake()
    {
        expbar = GameObject.FindGameObjectWithTag("Exp Bar").GetComponent<ExpBar>();
        if (gameObject.CompareTag("Player"))
        {
            healthbar = GameObject.FindGameObjectWithTag("Health Bar").GetComponent<HealthBar>();
            
        }
        else
        {
            score= GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
            
        }
    }
    void Start()
    {
        
        currentHealth = maxHealth;
        if(healthbar!=null)     
        {
            healthbar.SetMaxHealth(maxHealth); 
        }
        if(expbar!=null && gameObject.CompareTag("Player"))
        {
            expbar.SetMaxExp(expbar.level,0f);
        }
    }

   
    void Update()
    {
        if(invincible)
        {
            invincibletime();
            
        }
    }

    public void TakeDamage(float damage)
    {
        if (invincible == false)
        {
            currentHealth -= damage;

            if(healthbar!=null)
            {
                healthbar.SetHealth(currentHealth); 
            }

            if(gameObject.CompareTag("Player"))
            {
                invincible = true;
                currentInvincibleTime = maxInvincibleTime;
            }
        }
        if(currentHealth<=0)
        {
            if (gameObject.CompareTag("Player"))
            {
                canvas.transform.GetChild(5).transform.gameObject.SetActive(true);
            }
            else
            {
                expbar.SetExp(maxHealth / 100);
                score.ScoreUpdate(maxHealth);
            }
            
            if (deatheffect != null)
            {
                GameObject effect = Instantiate(deatheffect, transform.position, Quaternion.identity);
                Destroy(effect,2f);
            }
            Destroy(gameObject);
        }    

    }
    public void invincibletime()
    {
        currentInvincibleTime -= Time.deltaTime;
        if(currentInvincibleTime<=0)
        {
            invincible = false;
        }
    }
}
