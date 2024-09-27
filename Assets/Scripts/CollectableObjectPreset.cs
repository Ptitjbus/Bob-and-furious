using UnityEngine;

[CreateAssetMenu(fileName = "New Collectable Object", menuName = "Collectable/Object")]
public class CollectableObjectPreset : ScriptableObject
{
    public string objectName;
    public GameObject prefab;
}
