using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputController
{
    Vector3 GetPaddlePosition(Vector3 currentPosition);
}
