using UnityEngine;

[CreateAssetMenu(fileName = "ExampleBuilding", menuName = "BuildingInfos")]
public class BuildingSO : ScriptableObject
{
    [Header("Building GameObject")]
    public GameObject Building;

    [Header("Transform")]
    public float yPos;

    [Header("Type")]
    public int buildingType;

    [Header("Building name")]
    public string buildingTag;

    [Header("Requirements")]
    public Resources[] requiredResources;
}
