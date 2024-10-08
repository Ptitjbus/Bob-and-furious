using UnityEngine;

public class FPSRaycastController : BaseController<FPSRaycastController>
{
    public delegate void PickObjectEvent(string id);
    public event PickObjectEvent OnObjectPicked;

    public float raycastDistance = 5.0f;
    private GameObject lastHitObject;
    [SerializeField] Camera playerCamera;

    AudioController audioController;
    public bool isInTrigger = false;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    void Update()
    {
        DetectCollectableObject();
    }

    void DetectCollectableObject()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("CollectableObject"))
            {
                lastHitObject = hitObject;

                // When the player presses the E key, the object is picked up
                if (Input.GetKeyDown(KeyCode.E)) {
                    CollectableObject collectableObject = lastHitObject.GetComponent<CollectableObject>();
                    if (collectableObject.id != null) {
                        OnObjectPicked?.Invoke(collectableObject.id);
                    }
                    if(collectableObject.onCollect != null) {
                        collectableObject.onCollect.OnEvent();
                    }
                    audioController.PlaySFX(audioController.collectable);
                    lastHitObject.SetActive(false);
                }
                UIController.Instance().interractHelper.SetActive(true);
            }
            else
            {
                lastHitObject = null;
                UIController.Instance().interractHelper.SetActive(isInTrigger);
            }
        }
        else
        {
            lastHitObject = null;
            UIController.Instance().interractHelper.SetActive(isInTrigger);
        }
    }

    // Add a guizmo for debugging
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(playerCamera.transform.position, playerCamera.transform.position + playerCamera.transform.forward * raycastDistance);
    }

    public GameObject GetLastHitObject()
    {
        return lastHitObject;
    }
}
