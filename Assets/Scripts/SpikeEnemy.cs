using UnityEngine;

public class SpikeEnemy : MonoBehaviour
{
    public float maxTime = 3f, currentTime;
    SpriteRenderer spriteRenderer;
    public Sprite normal, attack;
    public float damage = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normal;
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        currentTime -= Time.deltaTime;
        if(currentTime<=0)
        {
            if (spriteRenderer.sprite == normal)
            {
                spriteRenderer.sprite = attack;
                gameObject.GetComponent<CircleCollider2D>().radius = 2.7f;
            }
            else
            {
                spriteRenderer.sprite = normal;
                gameObject.GetComponent<CircleCollider2D>().radius = 1.99f;
            }
            currentTime = maxTime;
        }

        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

    }
}
