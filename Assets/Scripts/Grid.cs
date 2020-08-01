using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] private int CellSize = 1;

    public Vector3 WorldToGrid(Vector3 position)
    {
        return new Vector3(
            Mathf.RoundToInt(position.x / CellSize) * CellSize,
            0f,
            Mathf.RoundToInt(position.z / CellSize) * CellSize
        );
    }

    private void OnDrawGizmos()
    {
        for (int x = CellSize; x < 15 * CellSize; x += CellSize)
        {
            for (int y = 0; y < 15 * CellSize - CellSize; y += CellSize)
            {
                Gizmos.DrawLine(WorldToGrid(new Vector3(x - CellSize, 0f, y)), WorldToGrid(new Vector3(x, 0f, y)));
                Gizmos.DrawLine(WorldToGrid(new Vector3(x, 0f, y)), WorldToGrid(new Vector3(x, 0f, y + CellSize)));
            }
        }
    }

}
