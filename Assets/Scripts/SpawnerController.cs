using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : BaseController<SpawnerController>
{
    public CollectableObject collectableObject;

    public delegate void ObjectSpawnedEvent(CollectableObject collectableObject);
    public event ObjectSpawnedEvent OnObjectSpawned;

    public int spawnCount = 5;

    [Header("Liste des Presets")]
    public List<CollectableObjectPreset> objectsToSpawn;

    [Header("Points de Spawn")]
    public List<Transform> spawnPoints;

    void Start() {
        SpawnObjects();
    }

    void SpawnObjects() {
        if (objectsToSpawn.Count < spawnCount || spawnPoints.Count < spawnCount) {
            Debug.LogWarning("Il n'y a pas assez d'objets ou de points de spawn disponibles.");
            return;
        }

        // Sélectionner aléatoirement les objets uniques dans la liste des prefabs
        List<CollectableObjectPreset> selectedObjects = GetRandomSelection(objectsToSpawn, spawnCount);

        // Sélectionner aléatoirement les points de spawn uniques
        List<Transform> selectedSpawnPoints = GetRandomSelection(spawnPoints, spawnCount);

        for (int i = 0; i < selectedObjects.Count; i++) {
            GameObject obj = Instantiate(collectableObject.gameObject, selectedSpawnPoints[i].position, selectedSpawnPoints[i].rotation);
            var collectable = obj.GetComponent<CollectableObject>();
            collectable.preset = selectedObjects[i];
            collectable.id = i.ToString();
            OnObjectSpawned?.Invoke(collectable);
        }
    }

    // Select random items from a list
    List<T> GetRandomSelection<T>(List<T> list, int count) {
        List<T> copy = new List<T>(list);
        List<T> selection = new List<T>();

        for (int i = 0; i < count; i++) {
            int index = Random.Range(0, copy.Count);
            selection.Add(copy[index]);
            copy.RemoveAt(index);
        }

        return selection;
    }
}
