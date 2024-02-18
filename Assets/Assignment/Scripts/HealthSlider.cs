using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSlider : MonoBehaviour
{
    public Slider healthSlider;

    private void Start()
    {
        healthSlider.value = 5;
    }
    // Start is called before the first frame update
    void takeDamage()
    {
        healthSlider.value--;
    }
}
