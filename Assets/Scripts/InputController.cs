using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : BaseController<InputController>
{
    public delegate void InputEvent();
    public event InputEvent OnLPressed;
    public event InputEvent OnEscapePressed;



    void Update()
    {
        // ecouteur de la touche L
        if (Input.GetKeyDown(KeyCode.L))
        {
            OnLPressed?.Invoke();
        }

        // ecouteur de la touche P
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnEscapePressed?.Invoke();
        }
    }
}
