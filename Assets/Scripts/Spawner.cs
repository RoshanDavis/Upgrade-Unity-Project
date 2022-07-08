using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxX, maxY, minX, minY;
    public float maxTime=3f, currentTime;
    public GameObject[] enemies;
    int i = 0;
    void Start()
    {
        currentTime = maxTime;
    }

    
    void Update()
    {
        Timer();
    }

    public void Timer()
    {
        currentTime -= Time.deltaTime;
        if(currentTime<=0)
        {
            float randx = Random.Range(minX,maxX);
            float randy = Random.Range(minY, maxY);
            Vector2 loc = new Vector2(randx, randy);
            int n = Random.Range(0, enemies.Length);
            Instantiate(enemies[n], loc, Quaternion.identity);
            currentTime = maxTime;
            if(maxTime>0.5f && i==5)
            {
                maxTime -= 0.1f;
                i = 0;
            }
            i++;
        }
    }
}
