using UnityEngine;

public class GameData : MonoBehaviour
{
    #region Singleton
    private static GameData _instance;
    public static GameData Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject newInstance = new GameObject("GameData");
                newInstance.AddComponent<GameData>();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    #endregion

    public Resources[] playerResources;
}
