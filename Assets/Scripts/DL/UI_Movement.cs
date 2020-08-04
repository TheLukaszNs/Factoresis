using UnityEngine;

public class UI_Movement : MonoBehaviour
{
    private Animation MenuAnimation;

    private bool isExpanded = false;

    private void Start()
    {
        MenuAnimation = GetComponent<Animation>();
    }

    public void ExpandOrCollapse()
    {
        if (isExpanded)
        {
            MenuAnimation.Play("CollapseBuildingMenu");
            isExpanded = false;
        }
        else
        {
            MenuAnimation.Play("ExpandBuildingMenu");
            isExpanded = true;
        }
    }
}
