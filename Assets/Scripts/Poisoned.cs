
using UnityEngine;

public class Poisoned : MonoBehaviour
{
    public float poisonTime=0.3f,poisonDamage;
    private int i = 10;
    
    public void PoisonValue(float pd)
    {
        poisonDamage = pd;
        Poison();
        transform.GetChild(0).transform.gameObject.SetActive(true);
    }
    public void Poison()
    {
        gameObject.GetComponent<Health>().TakeDamage(poisonDamage);
        
        if(i>0)
        {
            Invoke("Poison", poisonTime);
            i--;
        }
        else
        {
            i = 10;
            transform.GetChild(0).transform.gameObject.SetActive(false);
        }
    }
}
