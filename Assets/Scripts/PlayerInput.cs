using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    float hInput = 0;
    float vInput = 0;
    int inputType = 0;//0keyboard 1acelerometer
    Vector3 mousePos;
    Vector3 clickPos;
    Vector3 smoothPos;
    Vector3 mouseVelocity;
    bool hasControl = true;

    public float HorizontalAxis
    {
        get
        {
            return hInput;
        }
    }

    public float VerticalAxis
    {
        get
        {
            return vInput;
        }
    }

    public void Disable()
    {
        hInput = 0;
        vInput = 0;
        this.hasControl = false;
    }

    public void Enable()
    {
        hInput = 0;
        vInput = 0;
        this.hasControl = true;
    }

    private void Start()
    {
        #if UNITY_ANDROID
            inputType = 1;
            PlayerVars.acceleration = 300;
            PlayerVars.dessaceleration = 5;
            PlayerVars.maxMoveSpeed = 2.5f;
            PlayerVars.mouseSmoothTime = 4.5f;
            PlayerVars.sensitivity = 400;
        #endif

        #if UNITY_EDITOR
            inputType = 0;
        #endif

        #if UNITY_EDITOR_WIN
            inputType = 0;
        #endif

        #if UNITY_STANDALONE
            inputType = 0;
        #endif

    }
    
    private void Update()
    {
        if (!this.hasControl)
            return;

        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            this.inputType = this.inputType == 0 ? 1 : 0;
        }

        if (this.inputType == 0)
        {
            this.hInput = Input.GetAxisRaw("Horizontal");
            this.vInput = Input.GetAxisRaw("Vertical");
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                this.clickPos = new Vector3(Input.mousePosition.x, 0.0f, Input.mousePosition.y) / (float)Screen.height;
                this.smoothPos = this.clickPos;
            }

            if (Input.GetMouseButton(0))
            {
                this.mousePos = new Vector3(Input.mousePosition.x, 0.0f, Input.mousePosition.y) / (float)Screen.height;
                this.smoothPos = Vector3.Lerp(this.smoothPos, this.mousePos, Time.fixedDeltaTime * PlayerVars.mouseSmoothTime);
            }

            this.mouseVelocity = Vector3.zero;
            Vector3 distance = this.smoothPos - this.clickPos;
            Vector3 distanceWithSensitivity = distance * PlayerVars.sensitivity;

            this.clickPos = this.smoothPos;
            this.mouseVelocity += distanceWithSensitivity / Time.deltaTime;
            this.mouseVelocity = this.mouseVelocity.normalized;
            this.hInput = Mathf.RoundToInt(this.mouseVelocity.x);
            this.vInput = Mathf.RoundToInt(this.mouseVelocity.z);
        }
    }
}
