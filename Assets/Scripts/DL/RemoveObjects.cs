using UnityEngine;

public class RemoveObjects : MonoBehaviour
{
    public GameData gameData;
    public ObjectResources objectResources;

    public void DestroyObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            gameData = gameObject.GetComponent<BuildingManager>().gameData;
            objectResources = hit.collider.gameObject.GetComponent<ObjectResources>();

            if (hit.collider.tag == "Resources")
            {
                for (int i = 0; i < gameData.playerResources.Length; i++)
                {
                    for (int p = 0; p < objectResources.resources.Count; p++)
                    {
                        if (gameData.playerResources[i].resourceName == objectResources.resources[p].resourceName)
                        {
                            gameData.playerResources[i].resourceAmount += objectResources.resources[p].resourceAmount;
                        }
                    }
                }
            }

            Destroy(hit.collider.gameObject);
        }
    }
}
