using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    bool hasTarget = false;
    public Vector3 initialPos;
    bool justStartShaking = false;
    public bool shaking = false;
    public bool fixZero = false;
    Vector3 originalPosT;
    float _elapsed = 0;
    float _duration = 0;
    float _magnitude = 0;
    public static SmoothFollowCamera Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void RemoveTarget()
    {
        this.target = null;
        this.hasTarget = false;
    }

    public void SetTarget(Transform _target)
    {
        this.target = _target;
        this.hasTarget = true;
    }

    void LateUpdate()
    {
        if (!this.hasTarget)
            return;


        if (shaking)
        {
            if (_elapsed < _duration)
            {
                _elapsed += Time.deltaTime;

                float percentComplete = _elapsed / _duration;
                float damper = 1.0f - Mathf.Clamp(2.0f * percentComplete - 3.0f, 0.0f, 1.0f);

                float x = Random.value * 2.0f - 1.0f;
                float y = Random.value * 2.0f - 1.0f;
                x *= _magnitude * damper;
                y *= _magnitude * damper;

                Camera.main.transform.position = new Vector3(x, y, originalPosT.z);
            }
            else
            {
                StopShake();

            }
        }
        else
        {
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, -0.5f, 0.5f);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, -0.5f, 0.5f);


            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

        }








    }


    public void StopShake()
    {
        shaking = false;
        hasTarget = false;        
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
