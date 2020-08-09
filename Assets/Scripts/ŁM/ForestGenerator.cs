using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGenerator : MonoBehaviour
{
    public List<TreeType> trees = new List<TreeType>();

    private void Start()
    {
        for (float x = 0f; x < 100; x += 5f)
        {
            for (float z = 0f; z < 100; z += 5f)
            {
                foreach (TreeType tree in trees)
                {
                    if (Random.value <= tree.spawnRate)
                    {
                        Instantiate(tree.treePrefab, new Vector3(x, 0f, z), Quaternion.Euler(Vector3.up));
                        break;
                    }
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
