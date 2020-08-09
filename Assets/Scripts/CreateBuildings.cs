using UnityEngine;

public class CreateBuildings : MonoBehaviour
{
    [SerializeField] private Grid gridScript;

    [SerializeField] private GameObject buildingGO;

    [SerializeField] private string tag = "Building";

    private Vector3 currentPosition;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0) && !GameData.GridProperties.TryGetValue(gridScript.WorldToGrid(hit.point), out tag))
            {
                if (tag != "Building")
                {
                    GameData.GridProperties.Add(gridScript.WorldToGrid(hit.point), "Building");

                    currentPosition = new Vector3(gridScript.WorldToGrid(hit.point).x, 0f, gridScript.WorldToGrid(hit.point).z);
                    PlaceBuilding();

                    //Debug.Log(WorldToGrid(hit.point));
                }
            }

            if (GameData.GridProperties.ContainsValue("Building") && GameData.GridProperties.ContainsKey(gridScript.WorldToGrid(hit.point)))
            {
                //Debug.Log("Building!");
            }
        }
    }

    private void PlaceBuilding()
    {
        Instantiate(buildingGO, currentPosition, Quaternion.identity);
    }
}
