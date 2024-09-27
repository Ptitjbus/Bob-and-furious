using UnityEngine;

public class LightController : MonoBehaviour
{

    [SerializeField] private Light flashlight;

    float rotationX = 0;
    [SerializeField] private float lookSpeed = 2.0f;
    [SerializeField] private float lookXLimit = 45.0f;

    AudioController audioController;

    private void Awake()
    {
        audioController = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioController>();
    }

    void Start()
    {
        flashlight.gameObject.SetActive(false);
        InputController.Instance().OnFPressed += ToggleFlashlight;
    }

    public void ToggleFlashlight()
    {
        audioController.PlaySFX(audioController.lightSwitch);
        flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
    }

    void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        flashlight.gameObject.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }
}
