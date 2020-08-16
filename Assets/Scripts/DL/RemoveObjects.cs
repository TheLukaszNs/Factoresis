using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveObjects : MonoBehaviour
{
    public void DestroyObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
            Destroy(hit.collider.gameObject);
    }
}
