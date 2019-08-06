public class CookiesChangeReport : IReporteable
{
    public void Report()
    {
        EventsMan.Instance.Call_OnChangeCookies();
    }
}
