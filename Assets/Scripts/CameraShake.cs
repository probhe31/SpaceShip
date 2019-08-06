using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    public Vector3 initialPos;
    public bool shaking = false;
    public static CameraShake instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

        initialPos = Camera.main.transform.position;


    }

    void Update()
    {

        if (!shaking)
            return;

        if (_elapsed < _duration)
        {
            _elapsed += Time.deltaTime;

            float percentComplete = _elapsed / _duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= _magnitude * damper;
            y *= _magnitude * damper;

            Camera.main.transform.position = new Vector3(x, originalPosT.y, y);
        }
        else
        {
            StopShake();

        }

    }


    public void StopShake()
    {
        shaking = false;
        Camera.main.transform.position = originalPosT;
    }


    float _elapsed = 0;
    float _duration = 0;
    float _magnitude = 0;

    public void ShakeCamera(float duration, float magnitude)
    {
        initialPos = this.transform.position;

        Vector3 originalCamPos = initialPos;
        originalPosT = originalCamPos;


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


    Vector3 originalPosT;

    IEnumerator Shake(float duration, float magnitude)
    {

        float elapsed = 0.0f;

        //Vector3 originalCamPos = Camera.main.transform.position;
        //Debug.Log("init " + initialPos.x + "  "  + initialPos.y);

        Vector3 originalCamPos = initialPos;
        originalPosT = originalCamPos;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);


            yield return null;
        }

        //Vector3 roundOriginalCamPos = new Vector3(Mathf.Round(originalCamPos.x), Mathf.Round(originalCamPos.y), Mathf.Round(originalCamPos.z));
        //Camera.main.transform.position = originalCamPos;
        Camera.main.transform.position = originalCamPos;
    }

}
