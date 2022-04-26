using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text hp;
    [SerializeField] private Text ore;

    public void VisualHpChange(float newHp)
    {
        hp.text = newHp.ToString();
    }

    public void VisualOreChange(float newOre)
    {
        ore.text = newOre.ToString();
    }
    
}
