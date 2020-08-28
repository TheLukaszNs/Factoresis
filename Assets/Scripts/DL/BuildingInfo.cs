using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    [Header("Main information")]

    public bool isRemove, isResourceBuilding;

    public string buildingName;
    public int buildingType;

    public GameObject prefab;

    [Header("Resources information")]

    public Resource[] requiredResources;
    public ResourcesBuilding resourcesBuilding;
}

[System.Serializable]
public class ResourcesBuilding
{
    public Resource[] resourcesGatheredPerDay;
}
