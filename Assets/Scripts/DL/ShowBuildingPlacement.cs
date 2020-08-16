using UnityEngine;

public class ShowBuildingPlacement : MonoBehaviour
{
    private CursorInteractionManager MainScript;

    public GameObject FieldSelection;

    private Vector3 newBuildingPos;

    void Start()
    {
        MainScript = GetComponent<CursorInteractionManager>();
    }

    void Update()
    {
        int buildingType = MainScript.buildingInfo.buildingType;

        newBuildingPos = MainScript.currentPosition;

        if (buildingType > -1)
        {
            FieldSelection.SetActive(true);

            FieldSelection.transform.position = new Vector3(newBuildingPos.x, FieldSelection.transform.position.y, newBuildingPos.z);
            FieldSelection.transform.localScale = new Vector3(MainScript.buildingInfo.prefab.transform.lossyScale.x * 2, FieldSelection.transform.localScale.y, MainScript.buildingInfo.prefab.transform.lossyScale.z * 2);
        }
        else
        {
            FieldSelection.SetActive(false);
        }
    }
}
