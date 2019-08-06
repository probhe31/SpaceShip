using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeV2 : MonoBehaviour
{
    public Vector3 initialPos;
    bool justStartShaking = false;
    public bool shaking = false;
    public bool fixZero = false;
    Vector3 originalPosT;
    float _elapsed = 0;
    float _duration = 0;
    float _magnitude = 0;

    public static CameraShakeV2 Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        /*if (fixZero)
            initialPos = new Vector3(0, 0, -10f);
        else
            initialPos = Camera.main.transform.position;*/

    }

    void Update()
    {
        justStartShaking = shaking;

        if (!shaking)
            return;

        /*if (!justStartShaking)
        {
            initialPos = this.transform.position;
        }*/

        if (_elapsed < _duration)
        {
            _elapsed += Time.deltaTime;

            float percentComplete = _elapsed / _duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            float x = Random.value * 2.0f - 1.0f;
            float z = Random.value * 2.0f - 1.0f;
            x *= _magnitude * damper;
            z *= _magnitude * damper;

            Camera.main.transform.position = new Vector3(x, originalPosT.y, z);
        }
        else
        {
            StopShake();

        }

    }


    public void StopShake()
    {
        shaking = false;
        Vector3 endPos = new Vector3(originalPosT.x, this.transform.position.y, originalPosT.z);
        Camera.main.transform.position = endPos;
    }


    public void ShakeCamera(float duration, float magnitude)
    {
        Vector3 originalCamPos = this.transform.position;
        originalPosT = originalCamPos;
        
       
        magnitude *= 1;

        if (shaking)
        {
            //CASE1 = new magnitude equal
            if (_magnitude > 0 && magnitude == _magnitude)
            {
                _duration += duration;
            }

            //CASE1 = new magnitude major
            if (_magnitude > 0 && magnitude > _magnitude)
            {
                _elapsed = 0.0f;
                _magnitude = magnitude;
                _duration = duration;
            }


        }
        else
        {
            shaking = true;

            _elapsed = 0.0f;
            _duration = duration;
            _magnitude = magnitude;


        }

    }
}
