using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIInput : IInputController
{
    private float lastTime;
    private int direction;
    
    public void ControlPaddle(Slider slider)
    {
        slider.interactable = false;

        if (Time.time - lastTime > 1)
        {
            lastTime = Time.time;
            direction = Random.Range(0, 2);
        }

        if (direction == 1)
        {
            slider.value += 0.1f * Time.deltaTime;
        }
        else
        {
            slider.value -= 0.1f * Time.deltaTime;
        }
    }
}
