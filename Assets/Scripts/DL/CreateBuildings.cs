using UnityEngine;

public class CreateBuildings : MonoBehaviour
{
    [SerializeField] private Grid gridScript;

    [SerializeField] private GameObject[] Buildings;

    [SerializeField] private string tag;

    [SerializeField] private int buildingType;
    [SerializeField] private string buildingTag;

    private RaycastHit hit;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0) && !GameData.GridProperties.TryGetValue(gridScript.WorldToGrid(hit.point), out tag) && buildingTag != "")
            {
                if (tag == null)
                {
                    PlaceBuilding(Buildings[buildingType]);
                }
            }
        }
    }

    private void PlaceBuilding(GameObject buildingObject)
    {
        GameData.GridProperties.Add(gridScript.WorldToGrid(hit.point), buildingTag);

        Vector3 currentPosition = gridScript.WorldToGrid(hit.point);

        Instantiate(buildingObject, currentPosition, Quaternion.identity);
    }

    public void GetBuildingType(BuildingInfo info)
    {
        buildingType = info.buildingType;
        buildingTag = info.buildingTag;
    }
}
