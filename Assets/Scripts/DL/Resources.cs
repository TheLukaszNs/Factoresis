public enum ResourceNames
{
    Wood,
    Stone,
    Workers,
    Gold
}

[System.Serializable]
public class Resource
{
    public ResourceNames resourceName;
    public int resourceAmount;

    public Resource(ResourceNames name, int amount)
    {
        resourceName = name;
        resourceAmount = amount;
    }
}
