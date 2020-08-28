using UnityEngine;

public class ShowBuildingPlacement : MonoBehaviour
{
    private BuildingManager MainScript;

    private GameObject BuildingPreview;

    private Vector3 newBuildingPos;

    void Start()
    {
        MainScript = GetComponent<BuildingManager>();
    }

    void Update()
    {
        int buildingType = MainScript.buildingInfo.buildingType;

        if (buildingType > -1)
        {
            if (BuildingPreview == null)
            {
                BuildingPreview = Instantiate(MainScript.buildingInfo.prefab);
                Destroy(BuildingPreview.GetComponent<BoxCollider>());

                BuildingPreview.GetComponent<Renderer>().sharedMaterial = Resources.Load("BuildingPreviewMat", typeof(Material)) as Material;
            }

            if (MainScript.CheckIfRequirementsAreMet() && MainScript.CheckIfThereIsPlaceForBuilding())
            {
                BuildingPreview.GetComponent<Renderer>().sharedMaterial.color = Color.white;
                Debug.Log("Gooooood!");
            }
            else
            {
                BuildingPreview.GetComponent<Renderer>().sharedMaterial.color = Color.red;
                Debug.Log("Nope!");
            }

            BuildingPreview.SetActive(true);

            ChangePreviewPositionAndScale();
            ChangeBuildingRotation();
        }
        else if (BuildingPreview != null)
        {
            BuildingPreview.SetActive(false);
        }
    }

    private void ChangePreviewPositionAndScale()
    {
        newBuildingPos = MainScript.gridScript.WorldToGrid(MainScript.hit.point);
        newBuildingPos.y = MainScript.buildingInfo.prefab.transform.position.y;

        BuildingPreview?.SetActive(true);

        BuildingPreview.transform.position = new Vector3(newBuildingPos.x, BuildingPreview.transform.position.y, newBuildingPos.z);
        BuildingPreview.transform.localScale = MainScript.buildingInfo.prefab.transform.lossyScale;
    }

    private void ChangeBuildingRotation()
    {
        if (Input.GetMouseButtonDown(2))
        {
            MainScript.buildingRot.eulerAngles += new Vector3(0f, 90f, 0f);
            BuildingPreview.transform.rotation = MainScript.buildingRot;
        }
    }
}
