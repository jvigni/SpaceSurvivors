using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();    
    }

    public void Init(float maxValue) 
    {
        slider.maxValue = maxValue;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }    
}
