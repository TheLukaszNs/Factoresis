using UnityEngine;

public class ShowBuildingPlacement : MonoBehaviour
{
    private CreateBuildings MainScript;

    [SerializeField] private GameObject[] Buildings;

    [SerializeField] private Vector3 newBuildingPos;

    void Start()
    {
        MainScript = GetComponent<CreateBuildings>();
    }

    void Update()
    {
        newBuildingPos = MainScript.currentPosition;

        if (MainScript.buildingType == -1)
        {
            for (int i = 0; i < Buildings.Length; i++)
            {
                Buildings[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < Buildings.Length; i++)
            {
                if (i == MainScript.buildingType && MainScript.buildingTag != "")
                {
                    Buildings[i].SetActive(true);

                    Buildings[i].transform.position = new Vector3(newBuildingPos.x, Buildings[i].transform.position.y, newBuildingPos.z);
                }
                else
                {
                    Buildings[i].SetActive(false);
                }
            }
        }
    }
}
