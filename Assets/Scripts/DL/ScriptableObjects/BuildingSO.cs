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
    public ResourcesRequired[] req;

    [System.Serializable]
    public class ResourcesRequired
    {
        public string resourceName;
        public int resourceAmount;
    }
}
