using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerbar : MonoBehaviour
{
    [SerializeField] private GameObject powerBar;
    [SerializeField] private Image powerBarMask;
    [SerializeField] private float barChangeSpeed;
    private float maxValue = 100;
    public float currentValue = 0f;
    private bool powerBarIncreasing;
    private bool powerBarOn;

    private void Start()
    {
        currentValue = 0;
        powerBarIncreasing = true;
        powerBarOn = true;
    }

    private void Update() => UpdatePowerbar();

    private void UpdatePowerbar()
    {
        if (powerBarOn)
        {
            if(!powerBarIncreasing)
            {
                currentValue -= barChangeSpeed;
                if(currentValue <= 0)
                    powerBarIncreasing = true;
            }
            else
            {
                currentValue += barChangeSpeed;
                if(currentValue >= maxValue)
                    powerBarIncreasing = false;
            }
            float fill = currentValue / maxValue;
            powerBarMask.fillAmount = fill;
        }
    }

    public void DisactivatePowerbar()
    {
        powerBarOn = false;
        powerBar.SetActive(false);
    }
}