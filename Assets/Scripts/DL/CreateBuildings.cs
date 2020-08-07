using UnityEngine;

public class CreateBuildings : MonoBehaviour
{
    [SerializeField] private Grid gridScript;

    [SerializeField] private GameObject[] Buildings;

    [SerializeField] private string tag;

    private float buildingYPos;
    [SerializeField] private int buildingType;
    [SerializeField] private string buildingTag;

    private RaycastHit hit;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (buildingType == -1)
                {
                    RemoveBuilding();
                }

                if (!GameData.GridProperties.TryGetValue(gridScript.WorldToGrid(hit.point), out tag) && buildingTag != "")
                {
                    if (tag == null && buildingType >= 0)
                    {
                        PlaceBuilding(Buildings[buildingType]);
                    }
                }
            }
        }
    }

    private void PlaceBuilding(GameObject buildingObject)
    {
        GameData.GridProperties.Add(gridScript.WorldToGrid(hit.point), buildingTag);

        Vector3 currentPosition = gridScript.WorldToGrid(hit.point);
        currentPosition.y = buildingYPos;

        Instantiate(buildingObject, currentPosition, Quaternion.identity);
    }

    private void RemoveBuilding()
    {
        if (hit.collider != null)
        {
            if (hit.collider.name != "Plane")
            {
                Destroy(hit.collider.gameObject);

                GameData.GridProperties.Remove(gridScript.WorldToGrid(hit.point));
            }
        }
    }

    public void GetBuildingType(BuildingInfo info)
    {
        buildingYPos = info.YPos;
        buildingType = info.buildingType;
        buildingTag = info.buildingTag;
    }
}
