using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class UIController : BaseController<UIController>
{
    public Transform MainCanvas;
    private GameObject _popUpContainer;

    public GameObject interractHelper;
    public GameObject ToDoList;
    public ListItem ListItem;

    public List<ListItem> listItems;

    public GameObject hint;

    private bool _fIsPressed = false;

    void Awake() {
        interractHelper.SetActive(false);
        SpawnerController.Instance().OnObjectSpawned += OnSpawned;
        FPSRaycastController.Instance().OnObjectPicked += CheckListItem;
        InputController.Instance().OnFPressed += OnFPressed;
    }

    // Start is called before the first frame update
    void Start() {
        // add the TogglePauseScreen function to the OnEscapePressed event
        InputController.Instance().OnEscapePressed += TogglePauseScreen;
        StartCoroutine(ShowHintAfterDelay(15.0f));
    }

    // Create a new item in the list
    void OnSpawned(CollectableObject collectableObject) {
        ListItem item = Instantiate(ListItem, ToDoList.transform);
        item.Id = collectableObject.id;
        item.text.text = collectableObject.preset.objectName;
        listItems.Add(item);
    }

    void OnFPressed() {
        _fIsPressed = true;
        if (_fIsPressed) {
            hint.gameObject.SetActive(false);
        }
    }

    // Check if the item is in the list and check it
    void CheckListItem(string id) {
        ListItem item = listItems.Find(x => x.Id == id);
        if (item != null) {
            item.toggle.isOn = true;
        }
    }

    private IEnumerator ShowHintAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        if (!_fIsPressed)
            hint.gameObject.SetActive(true);
    }

    // quit the game
    public void Quit() {
        Application.Quit();
    }

    // show the pause screen
    void TogglePauseScreen() {
        // if the popup is already open, we close it
        CloseAndDestropPopup();

        if (_popUpContainer == null) {
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
    void CloseAndDestropPopup() {
        if (_popUpContainer != null) {
            Cursor.visible = false;
            GameObject.Destroy(_popUpContainer);
        }
    }
}
