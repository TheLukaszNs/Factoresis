using UnityEngine;
using UnityEngine.EventSystems;

public class CreateBuildings : MonoBehaviour
{
    public Grid gridScript;

    public GameObject[] Buildings;

    public GameData gameData;
    private BuildingSO buildingSO;

    [SerializeField] private string selectedTag;

    private float buildingYPos;
    [SerializeField] private int buildingType;
    [SerializeField] private string buildingTag;

    private RaycastHit hit;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (buildingType == -1)
                    {
                        RemoveBuilding();
                    }

                    if (!MapData.GridProperties.TryGetValue(gridScript.WorldToGrid(hit.point), out selectedTag) && buildingTag != "")
                    {
                        if (selectedTag == null && buildingType >= 0)
                        {
                            if (CheckIfRequirementsAreMet())
                            {
                                PlaceBuilding(Buildings[buildingType]);
                                UseResources();
                            }
                        }
                    }
                }
            }
        }
    }

    private void PlaceBuilding(GameObject buildingObject)
    {
        MapData.GridProperties.Add(gridScript.WorldToGrid(hit.point), buildingTag);

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

                MapData.GridProperties.Remove(gridScript.WorldToGrid(hit.point));
            }
        }
    }

    public void GetBuildingType(BuildingInfo info)
    {
        buildingYPos = info.yPos;
        buildingType = info.buildingType;
        buildingTag = info.buildingTag;

        buildingSO = info.buildingSO;
    }

    private bool CheckIfRequirementsAreMet()
    {
        if (gameData.wood >= buildingSO.wood && gameData.stone >= buildingSO.stone && gameData.workers >= buildingSO.workers && gameData.gold >= buildingSO.gold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UseResources()
    {
        gameData.wood -= buildingSO.wood;
        gameData.stone -= buildingSO.stone;
        gameData.workers -= buildingSO.workers;
        gameData.gold -= buildingSO.gold;
    }
}
