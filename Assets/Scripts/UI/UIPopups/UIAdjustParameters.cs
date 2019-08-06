using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIAdjustParameters : UIPopup
{

    public InputField accel;
    public InputField dessacel;
    public InputField maxmove;
    public InputField smooth;
    public InputField sensitivity;

    public PlayerMovement playerControl;



    protected override void OnClose()
    {
        //playerControl.SetParameters(int.Parse(accel.text), int.Parse(dessacel.text), int.Parse(accel.text));
        PlayerVars.acceleration = int.Parse(accel.text);
        PlayerVars.dessaceleration = int.Parse(dessacel.text);
        PlayerVars.maxMoveSpeed = int.Parse(maxmove.text);
        PlayerVars.sensitivity = float.Parse(sensitivity.text);
        PlayerVars.mouseSmoothTime = float.Parse(smooth.text);

    }

    protected override void OnOpen()
    {
        this.accel.text = PlayerVars.acceleration.ToString();
        this.dessacel.text = PlayerVars.dessaceleration.ToString();
        this.maxmove.text = PlayerVars.maxMoveSpeed.ToString();
        this.sensitivity.text = PlayerVars.sensitivity.ToString();
        this.smooth.text = PlayerVars.mouseSmoothTime.ToString();

    }
}
