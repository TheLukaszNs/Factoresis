using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingManager : MonoBehaviour
{
    public Grid gridScript;

    public Transform BuildingsParent;

    [HideInInspector] public RaycastHit hit;
    [HideInInspector] public Quaternion buildingRot;

    [Header("Game Data")]
    public GameData gameData;
    public BuildingInfo buildingInfo;

    private void Update()
    {
        RaycastCheck();
    }

    #region Building Section
    private void RaycastCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
            if (!EventSystem.current.IsPointerOverGameObject())
                if (Input.GetMouseButtonDown(0))
                {
                    int buildingType = buildingInfo.buildingType;

                    if (hit.collider.tag == "IgnoreRaycast")
                    {
                        if (buildingType >= 0 && CheckIfThereIsPlaceForBuilding() && CheckIfRequirementsAreMet())
                        {
                            PlaceBuilding(buildingInfo.prefab);
                            UseResources();
                        }
                    }
                    else if (hit.collider != null && buildingInfo.isRemove)
                    {
                        FindObjectOfType<RemoveObjects>().DestroyObject();
                    }
                }
    }

    private void PlaceBuilding(GameObject buildingObject)
    {
        Vector3 currentPosition;

        currentPosition = gridScript.WorldToGrid(hit.point);
        currentPosition.y = buildingInfo.prefab.transform.position.y;

        GameObject BuildingGO = Instantiate(buildingObject, currentPosition, buildingRot);
        BuildingGO.transform.SetParent(BuildingsParent);

        BuildingEffects();
    }

    private void BuildingEffects()
    {
        for (int i = 0; i < gameData.resourcesGatheredPerDay.Length; i++)
        {
            for (int p = 0; p < buildingInfo.resourcesBuilding.resourcesGatheredPerDay.Length; p++)
            {
                if (gameData.resourcesGatheredPerDay[i].resourceName == buildingInfo.resourcesBuilding.resourcesGatheredPerDay[p].resourceName)
                {
                    gameData.resourcesGatheredPerDay[i].resourceAmount += buildingInfo.resourcesBuilding.resourcesGatheredPerDay[p].resourceAmount;
                }
            }
        }
    }

    public void GetBuildingType()
    {
        buildingInfo = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<BuildingInfo>();
    }

    private void UseResources()
    {
        for (int i = 0; i < gameData.playerResources.Length; i++)
        {
            for (int p = 0; p < buildingInfo.requiredResources.Length; p++)
            {
                if (gameData.playerResources[i].resourceName == buildingInfo.requiredResources[p].resourceName)
                {
                    gameData.playerResources[i].resourceAmount -= buildingInfo.requiredResources[p].resourceAmount;
                }
            }
        }
    }
    #endregion

    #region Check If Possible To Build
    public bool CheckIfRequirementsAreMet()
    {
        bool result = false;

        for (int i = 0; i < gameData.playerResources.Length; i++)
        {
            for (int p = 0; p < buildingInfo.requiredResources.Length; p++)
            {
                if (gameData.playerResources[i].resourceName == buildingInfo.requiredResources[p].resourceName)
                {
                    if (gameData.playerResources[i].resourceAmount >= buildingInfo.requiredResources[p].resourceAmount)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        return result;
                    }
                }
            }
        }

        return result;
    }

    public bool CheckIfThereIsPlaceForBuilding()
    {
        bool result = false;

        Collider[] colliders = Physics.OverlapBox(gridScript.WorldToGrid(hit.point), buildingInfo.prefab.transform.localScale * 0.5f);

        if (colliders != null)
        {
            foreach (Collider coll in colliders)
            {
                if (coll.tag != "IgnoreRaycast") 
                {
                    result = false;
                    break;
                }
                else
                {
                    result = true;
                }
            }
        }
        else
        {
            result = true;
        }

        return result;
    }
    #endregion
}
