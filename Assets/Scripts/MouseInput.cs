using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseInput : IInputController
{
    public void ControlPaddle(Slider slider)
    {
        slider.interactable = true;
        slider.value = Input.mousePosition.x / Screen.width;
    }
}
