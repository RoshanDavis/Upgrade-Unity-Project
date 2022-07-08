using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 20f;
    public GameObject explosion;
    public float damage = 1f;

    private Vector3 lastPosition;
    private float totalDistance;
    public float maxDistance = 3f;

    public bool poison=false;
    public float poisonDamage=1f;

    public bool explosionUpgrade = false;
    public float explosionRadius=0.5f;
    public LayerMask enemyMask;
    public GameObject BulletExplosion;
    private void Start()
    {
        lastPosition = transform.position;
    }
    void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.AddForce(transform.right*bulletSpeed, ForceMode2D.Impulse);
        rb.velocity = bulletSpeed * transform.right;
        float distance = Vector3.Distance(lastPosition, transform.position);
        totalDistance += distance;
        lastPosition = transform.position;
        if(totalDistance>=maxDistance)
        {
            if(explosionUpgrade)
            {
                ExplosiveBullet();
            }
            DestroyBullet();
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Boundary")
        {
            ExplosiveBullet();
            DestroyBullet();
        }
        if(collision.collider.tag=="Enemy")
        {
            collision.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
            if (poison)
            {
                collision.collider.gameObject.GetComponent<Poisoned>().PoisonValue(poisonDamage);
            }
            if(explosionUpgrade)
            {
                ExplosiveBullet();
            }
            DestroyBullet();    
        }
        
    }
    public void DestroyBullet()
    {
        GameObject effect = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);   
    }
  
    public void ExplosiveBullet()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyMask);
        Instantiate(BulletExplosion, transform.position, Quaternion.identity);
        for (int i = 0; i < enemies.Length; i++)
        {
            
            enemies[i].GetComponent<Health>().TakeDamage(damage);

        }
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
        //Debug.Log("Drawn");
    }

}
