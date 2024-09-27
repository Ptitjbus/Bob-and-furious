using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : BaseController<UIController>
{
    public Transform MainCanvas;

    private GameObject _popUpContainer;

    // Start is called before the first frame update
    void Start()
    {
        // add the TogglePauseScreen function to the OnEscapePressed event
        InputController.Instance().OnEscapePressed += TogglePauseScreen;
    }

    // quit the game
    public void Quit()
    {
        Application.Quit();
    }

    // show the pause screen
    void TogglePauseScreen()
    {
        // if the popup is already open, we close it
        CloseAndDestropPopup();

        if (_popUpContainer == null)
        {
            _popUpContainer = Instantiate(Resources.Load("UI/PopUpContainer")) as GameObject;
            _popUpContainer.transform.SetParent(MainCanvas);
            _popUpContainer.transform.localScale = Vector3.one;
            _popUpContainer.transform.localPosition = Vector3.zero;

            // we unlock the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // close the popup
    void CloseAndDestropPopup()
    {
        if (_popUpContainer != null)
        {
            Cursor.visible = false;
            GameObject.Destroy(_popUpContainer);
        }
    }
}
