using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text score;
    float sc = 0;
    void Start()
    {
        score.text = "SCORE : 0";
    }

    public void ScoreUpdate(float s)
    {
        sc += s;
        score.text="SCORE : "+sc.ToString("0");
    }
    
}
