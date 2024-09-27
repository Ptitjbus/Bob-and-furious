using UnityEngine;

public class InputController : BaseController<InputController>
{
    public delegate void InputEvent();
    public event InputEvent OnFPressed;
    public event InputEvent OnEscapePressed;

    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            OnFPressed?.Invoke();
        }

        // ecouteur de la touche Escape
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnEscapePressed?.Invoke();
        }
    }
}
