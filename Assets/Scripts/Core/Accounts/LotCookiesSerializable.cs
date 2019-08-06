public class LotCookiesSerializable : IIntSerializable
{

    public int GetValue()
    {
        return DataMan.Instance.userData.LotCookies;
    }

    public void Save(int _amount)
    {
        DataMan.Instance.userData.LotCookies = _amount;
    }
}
