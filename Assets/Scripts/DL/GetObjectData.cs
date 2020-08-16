using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetObjectData : MonoBehaviour
{
    public Text objectInfoText;

    public Resources[] objectResources;

    private RaycastHit hit;

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
            if (!EventSystem.current.IsPointerOverGameObject())
                DetectObject();
                
    }

    void DetectObject()
    {
        if (hit.collider != null)
        {
            switch (hit.collider.tag)
            {
                case "Resources":
                    objectResources = hit.collider.gameObject.GetComponent<ObjectResources>().resources.ToArray();
                    SendInfoToText();
                    break;

                case "IgnoreRaycast":
                    objectResources = null;
                    objectInfoText.text = null;
                    break;
            }
        }
    }

    private void SendInfoToText()
    {
        objectInfoText.text = null;

        foreach (Resources resources in objectResources)
        {
            objectInfoText.text += resources.resourceName + ": " + resources.resourceAmount.ToString() + "\n";
        }
    }
}
