public class RedLightSerializable : IIntSerializable
{
    public void Save(int amount)
    {
        DataMan.Instance.userData.RedLights = amount;
    }

    public int GetValue()
    {
        return DataMan.Instance.userData.RedLights;
    }
}
