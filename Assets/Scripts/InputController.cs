using UnityEngine;

public class InputController : BaseController<InputController>
{
    public delegate void InputEvent();
    public event InputEvent OnFPressed;

    void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            OnFPressed?.Invoke();
        }
    }
}
