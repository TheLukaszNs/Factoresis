using UnityEngine;

public class ShowBuildingPlacement : MonoBehaviour
{
    private CreateBuildings MainScript;

    [SerializeField] private GameObject FieldSelection;

    private Vector3 newBuildingPos;

    void Start()
    {
        MainScript = GetComponent<CreateBuildings>();
    }

    void Update()
    {
        newBuildingPos = MainScript.currentPosition;

        if (MainScript.buildingType > -1)
        {
            FieldSelection.SetActive(true);

            FieldSelection.transform.position = new Vector3(newBuildingPos.x, FieldSelection.transform.position.y, newBuildingPos.z);
            FieldSelection.transform.localScale = new Vector3(MainScript.buildingSO.Building.transform.lossyScale.x * 2, FieldSelection.transform.localScale.y, MainScript.buildingSO.Building.transform.lossyScale.z * 2);
        }
        else
        {
            FieldSelection.SetActive(false);
        }
    }
}
