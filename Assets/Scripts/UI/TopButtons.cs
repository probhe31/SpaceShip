using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TopButtons : MonoBehaviour
{
    public EventTrigger storeBtn;
    public EventTrigger optionsBtn;

    private void Start()
    {
        EventTrigger.Entry entryStore = new EventTrigger.Entry();
        entryStore.eventID = EventTriggerType.PointerClick;
        entryStore.callback.AddListener((data) => { OnClickStoreBtn((PointerEventData)data); });
        storeBtn.triggers.Add(entryStore);

        EventTrigger.Entry entryOptions = new EventTrigger.Entry();
        entryOptions.eventID = EventTriggerType.PointerClick;
        entryOptions.callback.AddListener((data) => { OnClickOptionsBtn((PointerEventData)data); });
        optionsBtn.triggers.Add(entryOptions);
    }


    public void OnClickStoreBtn(PointerEventData data)
    {
        ScreenMan.Instance.OpenScene(Screens.StoreScreen);
    }

    public void OnClickOptionsBtn(PointerEventData data)
    {
        ScreenMan.Instance.OpenScene(Screens.OptionsScreen);
    }
}
