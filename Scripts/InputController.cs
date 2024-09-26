using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : BaseController<InputController>
{
    public delegate void InputEvent();
    public event InputEvent OnLPressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            OnLPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pause();
        }
    }

    public void Pause()
    {
        // pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
