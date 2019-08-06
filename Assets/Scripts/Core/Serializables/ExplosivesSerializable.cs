public class ExplosivesSerializable : IIntSerializable
{
    public void Save(int amount)
    {
        DataMan.Instance.userData.Explosives = amount;
    }

    public int GetValue()
    {
        return DataMan.Instance.userData.Explosives;
    }
}