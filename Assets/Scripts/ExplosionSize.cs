
using UnityEngine;

public class ExplosionSize : MonoBehaviour
{
    public Bullet bullet;
    public float r;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        r = bullet.explosionRadius-0.3f*bullet.explosionRadius;
        transform.localScale = new Vector2(r-2f, r-2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x<r)
        {
            transform.localScale = new Vector2(transform.localScale.x + 0.1f, transform.localScale.y + 0.1f);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
