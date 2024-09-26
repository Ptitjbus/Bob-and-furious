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
        // on ajoute la fonction TogglePauseScreen à l'événement OnPPressed
        InputController.Instance().OnPPressed += TogglePauseScreen;
    }


    void TogglePauseScreen()
    {
        CloseAndDestropPopup();

        if (_popUpContainer == null)
        {
            _popUpContainer = Instantiate(Resources.Load("UI/PopUpContainer")) as GameObject;
            _popUpContainer.transform.SetParent(MainCanvas);
            _popUpContainer.transform.localPosition = Vector3.zero;
        }
    }

    void CloseAndDestropPopup()
    {
        if (_popUpContainer != null)
        {
            GameObject.Destroy(_popUpContainer);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
