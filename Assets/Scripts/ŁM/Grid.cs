using UnityEngine;

public class Grid : MonoBehaviour
{
    public int CellSize = 5;

    public Vector3 WorldToGrid(Vector3 position)
    {
        return new Vector3(
            Mathf.RoundToInt(position.x / CellSize) * CellSize,
            0f,
            Mathf.RoundToInt(position.z / CellSize) * CellSize
        );
    }
}
