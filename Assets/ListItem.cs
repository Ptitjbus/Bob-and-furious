using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItem : MonoBehaviour
{
    public string Id;
    public Toggle toggle;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        toggle.isOn = false;
    }
}
