using UnityEngine;

public class LightController : MonoBehaviour
{

    [SerializeField] private Light flashlight;

    float rotationX = 0;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;

    void Start() {
        flashlight.gameObject.SetActive(false);
        InputController.Instance().OnLPressed += ToggleFlashlight;
    }

    private void ToggleFlashlight() {
        flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
    }

    void Update() {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        flashlight.gameObject.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
