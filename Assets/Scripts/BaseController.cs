using UnityEngine;

public class BaseController<ControllerType> : MonoBehaviour
where ControllerType : Object
{

    public static ControllerType instance = null;

    public static ControllerType Instance() {
        if (instance == null) {
            instance = FindObjectOfType<ControllerType>();
        }
        return instance;
    }
}
