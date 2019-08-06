public class DiamondsChangeReport : IReporteable
{
    public void Report()
    {
        EventsMan.Instance.Call_OnChangeDiamonds();
    }
}
