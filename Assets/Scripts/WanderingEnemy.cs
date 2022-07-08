using UnityEngine;

public class WanderingEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float maxTime = 5f, currentTime;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTime;
        rb.rotation = Random.Range(0f, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        Wander();
    }
    public void Wander()
    {
        rb.velocity = speed*transform.right;
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            rb.rotation = Random.Range(0f, 360f);
            currentTime = maxTime;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Bullet")
        {
            Vector3 v = Vector3.Reflect(gameObject.transform.right, collision.GetContact(0).normal);
            gameObject.transform.rotation = Quaternion.FromToRotation(Vector3.right, v);
        }
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

    }
}
