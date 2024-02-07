using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }

}
