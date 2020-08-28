using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public float mapSize;

    public List<ObjectType> mapObjects = new List<ObjectType>();
    public Grid grid;
    public Transform forest;

    private void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        for (float x = -mapSize; x <= mapSize; x += grid.CellSize)
            for (float z = -mapSize; z <= mapSize; z += grid.CellSize)
            {
                foreach (ObjectType mapObject in mapObjects)
                {
                    mapObject.objectPrefab.tag = "Resources";

                    if (Random.value <= mapObject.spawnRate)
                    {
                        Vector3 objectPos = grid.WorldToGrid(new Vector3(x, 0f, z));
                        Quaternion rotation = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);

                        GameObject objectGO = Instantiate(mapObject.objectPrefab, objectPos, Quaternion.identity);
                        mapObject.objectPrefab.GetComponentInChildren<Transform>().transform.rotation = rotation;

                        objectGO.AddComponent<ObjectResources>();

                        for (int i = 0; i < mapObject.resources.Length; i++)
                        {
                            objectGO.GetComponent<ObjectResources>().resources.Add(mapObject.resources[i]);
                        }

                        objectGO.transform.SetParent(forest);
                        break;
                    }
                }
            }
    }
}

[System.Serializable]
public class ObjectType
{
    public string name;
    public GameObject objectPrefab;
    public float spawnRate = .1f;

    public Resource[] resources;
}
