using UnityEngine;
using UnityEngine.UI;
public class Level : MonoBehaviour
{
    public Text level;
    public void LevelUpdate(int l)
    {
        level.text = "LEVEL : " +l ;
    }

}