using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    public BuildingSO buildingSO;

    [HideInInspector] public float yPos;
    [HideInInspector] public int buildingType;
    [HideInInspector] public string buildingTag;
    [HideInInspector] public int wood, stone, workers, gold;

    private void Update()
    {
        yPos = buildingSO.yPos;
        buildingType = buildingSO.buildingType;
        buildingTag = buildingSO.buildingTag;
        wood = buildingSO.wood;
        stone = buildingSO.stone;
        workers = buildingSO.workers;
        gold = buildingSO.gold;
    }
}
