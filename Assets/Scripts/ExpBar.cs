using UnityEngine;
using UnityEngine.UI;
public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public int level;
    float totalexp;
    public Level lev;
    public ExpSystem[] expSystem;
    
    public void Start()
    {
        lev = GameObject.FindGameObjectWithTag("Level").GetComponent<Level>();
        foreach (ExpSystem expSystem in expSystem)
        {
            expSystem.UpgradeGenerater();
        }


        level = 1;
        lev.LevelUpdate(level);
    }
    public void SetMaxExp(float maxexp,float exp)
    {
        slider.maxValue = maxexp;
        slider.value = exp;
    }
    public void SetExp(float exp)
    {
        totalexp += exp;
        slider.value =totalexp;
        if(slider.value==slider.maxValue)
        {
            level++;
            foreach (ExpSystem expSystem in expSystem)
            {
                expSystem.UpgradeGenerater();
            }
            SetMaxExp(level-level*0.5f,totalexp-slider.value);
            lev.LevelUpdate(level);
            totalexp = 0f;
        }
    }
}
