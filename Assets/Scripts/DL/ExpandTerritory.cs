using UnityEngine;

public class ExpandTerritory : MonoBehaviour
{
    public GameObject Plane;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Plane.transform.localScale.x < 230 && Plane.transform.localScale.z < 230)
        {
            Plane.transform.localScale += new Vector3(23.45f, 0, 23.45f);
        }
    }
}
