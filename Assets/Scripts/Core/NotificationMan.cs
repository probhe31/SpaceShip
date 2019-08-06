using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationMan : MonoBehaviour
{
    public UIMissionCompleteNotification missionCompleteNotification;
    public static NotificationMan Instance;
    //public Queue<UINotification> notifications;
    float cTime;
    float timeToHide = 3;
    bool hasItems = false;

    private void Awake()
    {
        Instance = this;
        this.hasItems = false;
        //notifications = new Queue<UINotification>();
        GameObject.DontDestroyOnLoad(this.gameObject);        
    }

    bool showing = false;

    public void Show_MissionCompleteNotification(string _text)
    {
        //
        //if (!showing) {
            missionCompleteNotification.Show(_text);
        //}
        this.cTime = 0;
        //notifications.Enqueue(missionCompleteNotification);
        hasItems = true;
    }

    private void Update()
    {
        if (!hasItems)
            return; 

        this.cTime += Time.deltaTime;
        if (this.cTime > this.timeToHide)
        {
            this.cTime = 0;
            missionCompleteNotification.Hide();
            /*notifications.Dequeue().Hide();
            if (notifications.Count == 0)
            {
                hasItems = false;
            }
            else
            {

            }*/
        }
    }

}
