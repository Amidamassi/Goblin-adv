using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private Text hp;

    public void VisualHpChange(float newHp)
    {
        hp.text = newHp.ToString();
    }
    
}
