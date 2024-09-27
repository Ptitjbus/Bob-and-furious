using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public CollectableObjectPreset preset;
    public string id;

    public OnEventStruct onCollect;

    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private MeshCollider meshCollider;

    private BoxCollider prefabBoxCollider;

    void Start() {
        meshFilter.mesh = preset.prefab.GetComponent<MeshFilter>().sharedMesh;
        meshRenderer.material = preset.prefab.GetComponent<MeshRenderer>().sharedMaterial;
        transform.localScale = preset.prefab.transform.localScale;
        if (preset.prefab.GetComponent<BoxCollider>() != null && this.GetComponent<BoxCollider>() != null) {
            prefabBoxCollider = preset.prefab.GetComponent<BoxCollider>();
            BoxCollider boxCollider = this.GetComponent<BoxCollider>();
            boxCollider.center = prefabBoxCollider.center;
            boxCollider.size = prefabBoxCollider.size;
        }
        meshCollider.sharedMesh = meshFilter.mesh;
    }
}
