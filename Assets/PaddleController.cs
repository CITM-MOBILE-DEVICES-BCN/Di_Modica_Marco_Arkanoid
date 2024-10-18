using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private IInputController inputController;
    public Transform ballTransform;
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
            transform.position = inputController.GetPaddlePosition(transform.position);
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
                inputController = new AIInput(ballTransform, iaSpeed, iaMargin);
                break;
        }
    }
}
