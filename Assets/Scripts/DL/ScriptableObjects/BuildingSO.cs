using UnityEngine;

[CreateAssetMenu(fileName = "ExampleBuilding", menuName = "BuildingInfos")]
public class BuildingSO : ScriptableObject
{
    [Header("Transform")]
    public float yPos;

    [Header("Type")]
    public int buildingType;

    [Header("Building name")]
    public string buildingTag;

    [Header("Requirements")]
    public int wood;
    public int stone;
    public int workers;
    public int gold;
}
