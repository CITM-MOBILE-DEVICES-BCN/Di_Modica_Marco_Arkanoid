using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleController : MonoBehaviour
{
    private IInputController inputController;
    public GameObject ballTransform;
    public Slider slider;
    public float iaSpeed = 5f;
    public float iaMargin = 0.5f;

    public enum InputType
    {
        Mouse,
        AI
    }

    public InputType currentInputType;

    void Start()
    {
        SetInputController(currentInputType);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentInputType = InputType.Mouse;
            SetInputController(currentInputType);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentInputType = InputType.AI;
            SetInputController(currentInputType);
        }

        if (inputController != null)
        {
            inputController.ControlPaddle(slider);
        }
    }

    private void SetInputController(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.Mouse:
                inputController = new MouseInput();
                break;
            case InputType.AI:
                inputController = new AIInput();
                break;
        }
    }
}
