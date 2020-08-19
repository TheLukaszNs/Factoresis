public enum ResourceNames
{
    Wood,
    Stone,
    Workers,
    Gold
}

[System.Serializable]
public class Resources
{
    public ResourceNames resourceName;
    public int resourceAmount;

    public Resources(ResourceNames name, int amount)
    {
        resourceName = name;
        resourceAmount = amount;
    }
}
