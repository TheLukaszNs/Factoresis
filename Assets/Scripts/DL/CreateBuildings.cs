﻿using UnityEngine;
using UnityEngine.EventSystems;

public class CreateBuildings : MonoBehaviour
{
    public Grid gridScript;

    [HideInInspector] public Vector3 currentPosition;

    private RaycastHit hit;

    [Header("Building Objects")]
    public GameObject[] Buildings;
    [SerializeField] private Transform BuildingsParent;

    [Header("Game Data")]
    public GameData gameData;
    [SerializeField] private BuildingSO buildingSO;

    [Header("Building Properties")]
    [SerializeField] private float buildingYPos;
    public int buildingType;
    public string buildingTag;

    private void Update()
    {
        RaycastCheck();
    }

    private void RaycastCheck()
    {
        // Position for the building preview in ShowBuildingPlacement.
        currentPosition = gridScript.WorldToGrid(hit.point);
        currentPosition.y = buildingYPos;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
            if (!EventSystem.current.IsPointerOverGameObject())
                if (Input.GetMouseButtonDown(0))
                {
                    if (buildingType == -1)
                        RemoveBuilding();

                    if (hit.collider.tag == "IgnoreRaycast")
                        if (buildingType >= 0)
                            if (CheckIfThereIsPlaceForBuilding() && CheckIfRequirementsAreMet())
                            {
                                PlaceBuilding(Buildings[buildingType]);
                                UseResources();
                            }
                }
    }

    private void PlaceBuilding(GameObject buildingObject)
    {
        GameObject BuildingGO = Instantiate(buildingObject, currentPosition, Quaternion.identity);
        BuildingGO.transform.SetParent(BuildingsParent);
    }

    private void RemoveBuilding()
    {
        if (hit.collider != null)
        {
            if (hit.collider.tag != "IgnoreRaycast")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }

    public void GetBuildingType(BuildingSO buildingInfo)
    {
        buildingSO = buildingInfo;

        buildingYPos = buildingSO.yPos;
        buildingType = buildingSO.buildingType;
        buildingTag = buildingSO.buildingTag;
    }

    private bool CheckIfRequirementsAreMet()
    {
        bool result = false;

        for (int i = 0; i < gameData.resources.Length; i++)
        {
            if (gameData.resources[i].resourceAmount >= buildingSO.req[i].resourceAmount)
            {
                result = true;
            }
            else
            {
                result = false;
                break;
            }
        }

        return result;
    }

    private void UseResources()
    {
        for (int i = 0; i < gameData.resources.Length; i++)
        {
            gameData.resources[i].resourceAmount -= buildingSO.req[i].resourceAmount;
        }
    }

    private bool CheckIfThereIsPlaceForBuilding()
    {
        bool result = false;

        Collider[] colliders = Physics.OverlapBox(gridScript.WorldToGrid(hit.point), Buildings[buildingType].transform.localScale * 0.9f);

        if (colliders != null)
        {
            foreach (Collider coll in colliders)
            {
                if (coll.tag == "Collider")
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
}
