using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public List<TreeType> trees = new List<TreeType>();
    public Grid grid;
    public Transform forest;

    private void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);

        for (float x = -100f; x <= 100f; x += grid.CellSize)
            for (float z = -100f; z <= 100f; z += grid.CellSize)
            {
                foreach (TreeType tree in trees)
                {
                    if (Random.value <= tree.spawnRate)
                    {
                        Vector3 treePos = grid.WorldToGrid(new Vector3(x, 0f, z));
                        Quaternion rotation = Quaternion.Euler(0f, Random.Range(0, 360f), 0f);

                        GameObject treeGO = Instantiate(tree.treePrefab, treePos, Quaternion.identity);
                        tree.treePrefab.transform.Find("TreeMesh").rotation = rotation;

                        treeGO.AddComponent<ObjectResources>();
                        treeGO.GetComponent<ObjectResources>().resources.Add(new Resources("Wood", Random.Range(5, 20)));
                        treeGO.GetComponent<ObjectResources>().resources.Add(new Resources("Workers", -10));

                        treeGO.transform.SetParent(forest);
                        break;
                    }
                }
            }
    }
}

[System.Serializable]
public class TreeType
{
    public string name;
    public GameObject treePrefab;
    public float spawnRate = .1f;
}
