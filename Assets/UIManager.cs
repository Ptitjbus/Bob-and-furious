using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseController<UIManager>
{

    public GameObject interractHelper;
    public GameObject ToDoList;
    public ListItem ListItem;

    public List<ListItem> listItems;

    void Awake() {
        interractHelper.SetActive(false);
        SpawnerController.Instance().OnObjectSpawned += OnSpawned;
        FPSRaycastController.Instance().OnObjectPicked += CheckListItem;

    }

    // Create a new item in the list
    void OnSpawned(CollectableObject collectableObject) {
        ListItem item = Instantiate(ListItem, ToDoList.transform);
        item.Id = collectableObject.id;
        item.text.text = collectableObject.preset.objectName;
        listItems.Add(item);
    }

    // Check if the item is in the list and check it
    void CheckListItem(string id) {
        ListItem item = listItems.Find(x => x.Id == id);
        if (item != null) {
            item.toggle.isOn = true;
        }
    }
}
