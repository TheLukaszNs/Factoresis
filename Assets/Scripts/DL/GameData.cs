using UnityEngine;

public class GameData : MonoBehaviour, IDayPassed
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

    private void Start()
    {
        _instance = this;
    }
    #endregion

    public Resources[] playerResources;
    public Resources[] resourcesGatheredPerDay;

    public void DayPassed()
    {
        for (int i = 0; i < playerResources.Length; i++)
        {
            playerResources[i].resourceAmount += resourcesGatheredPerDay[i].resourceAmount;
        }
    }
}
