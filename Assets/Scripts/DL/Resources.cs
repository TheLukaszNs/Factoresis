[System.Serializable]
public class Resources
{
    public string resourceName;
    public int resourceAmount;

    public Resources(string name, int amount)
    {
        resourceName = name;
        resourceAmount = amount;
    }
}
