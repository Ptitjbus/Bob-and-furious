using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public CollectableObjectPreset preset;
    public string id;

    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private MeshCollider meshCollider;

    void Start() {
        meshFilter.mesh = preset.prefab.GetComponent<MeshFilter>().sharedMesh;
        meshRenderer.material = preset.prefab.GetComponent<MeshRenderer>().sharedMaterial;
        meshCollider.sharedMesh = meshFilter.mesh;
    }
}
