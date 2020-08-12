using UnityEngine;

public class GameData : MonoBehaviour
{
    public Resources[] resources;

    [System.Serializable]
    public class Resources
    {
        public string resourceName;
        public int resourceAmount;
    }
}
