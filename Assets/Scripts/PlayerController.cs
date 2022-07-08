using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;

    public Camera cam;
    Vector2 mousePos;

    public GameObject bulletobj;
    public Transform firePoint;
    public int bulletnum = 1;
    public float recoil = 0.03f;

    public bool canFire = false;
    public float maxActivationTime = 1.5f,fireRate=1f;
    float currentActivationTime,fireRateTime;
    public GameObject ActivationEffect;
    void Start()
    {
        currentActivationTime = maxActivationTime;
        fireRateTime = 0f;
    }
    void Update()
    {
        Move();
        Mouse();
        if (Input.GetButtonDown("Fire1"))
        {
            transform.GetChild(0).transform.gameObject.SetActive(true);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            canFire = false;
            currentActivationTime = maxActivationTime;
            fireRateTime = 0f;
            transform.GetChild(0).transform.gameObject.SetActive(false);
            
        }
        else if (Input.GetButton("Fire1") && canFire==true)
        {
            transform.GetChild(0).transform.gameObject.SetActive(false);
            fireRateTime -= Time.deltaTime;
            if (fireRateTime <= 0)
            {
                Shoot();
                fireRateTime = fireRate;
            }
        }
        else if(Input.GetButton("Fire1") && canFire == false)
        {
            BulletActivation();
        }
    }
    public void Move()
    {
        Vector2 direction =new  Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.velocity=direction * speed;
    }
    public void Mouse()
    {
        mousePos=cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }
    public void Shoot()
    {
        for (int i = -(bulletnum - 1); i < bulletnum; i += 2)
        {
            
            GameObject bullet = Instantiate(bulletobj, firePoint.position, firePoint.rotation);
            bullet.transform.Rotate(0f, 0f, i * 7f, Space.Self);
        }
        Recoil();   
    }
    public void Recoil()
    {
        rb.AddForce(-transform.right * recoil);
    }

    public void BulletActivation()
    {
        currentActivationTime -= Time.deltaTime;
        if(currentActivationTime<=0)
        {
            canFire = true;
        }
    }
}

