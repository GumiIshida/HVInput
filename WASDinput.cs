using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDinput : MonoBehaviour, IHVInput
{
    private int HorizontalAxis = 0;
    private int VerticalAxis = 0;

    public int GetHorizontalAxis()
    {
        return HorizontalAxis;
    }

    public int GetVerticalAxis()
    {
        return VerticalAxis;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) HorizontalAxis = -1;
        else if (Input.GetKey(KeyCode.D)) HorizontalAxis = 1;
        else HorizontalAxis = 0;

        if (Input.GetKey(KeyCode.S)) VerticalAxis = -1;
        else if (Input.GetKey(KeyCode.W)) VerticalAxis = 1;
        else VerticalAxis = 0;
    }
}
