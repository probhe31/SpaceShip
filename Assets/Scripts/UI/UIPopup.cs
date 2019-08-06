using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnExitPopup();

public abstract class UIPopup : MonoBehaviour
{
    OnExitPopup callback_OnExitPopup;
    public virtual void Open(OnExitPopup onExitPopup)
    {
        callback_OnExitPopup = onExitPopup;
        Open();
    }

    public virtual void Open()
    {
        this.gameObject.SetActive(true);
        OnOpen();
    }

    public virtual void Close()
    {
        MissionMan.Instance.ShouldShowMissionAfterGamePopup = false;

        this.gameObject.SetActive(false);

        

        callback_OnExitPopup?.Invoke();

        OnClose();
    }

    protected abstract void OnOpen();
    protected abstract void OnClose();

}
