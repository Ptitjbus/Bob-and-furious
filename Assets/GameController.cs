using UnityEngine;

public class GameController : BaseController<GameController>
{
    [SerializeField] private GameObject endTrigger;

    private int collectedItems = 0;
    private int totalItems = 0;


    void Start() {
        FPSRaycastController.Instance().OnObjectPicked += CheckItem;
        totalItems = SpawnerController.Instance().spawnCount;
    }

    // Update is called once per frame
    private void CheckItem(string id) {
        if (id != null && id != "") {
            collectedItems++;
            if (collectedItems == totalItems) {
                Debug.Log("All items collected");
                endTrigger.SetActive(true);
            }
        }
    }
}
