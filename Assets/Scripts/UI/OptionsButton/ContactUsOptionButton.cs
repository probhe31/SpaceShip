using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactUsOptionButton : OptionButton
{
    public override void OnClick()
    {
        Application.OpenURL("http://planb.com.pe/");
    }
}
