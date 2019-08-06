using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    

    public void Initialize()
    {

    }

    private void Update()
    {
        if (!Game.Instance.player)
            return;

        if(Game.Instance.player.gameObject.transform.position.y-2 < this.transform.position.y)
        {
            this.transform.LookAt(Game.Instance.mainCameraTransform);
        }
        else
        {
            this.transform.LookAt(Game.Instance.player.transform);
            
        }

        /*Vector3 targetRotation = this.transform.localRotation.eulerAngles;
        targetRotation.y = Mathf.Clamp(targetRotation.y, -60, 60);
        targetRotation.x = Mathf.Clamp(targetRotation.x, -60, 60);
        this.transform.localRotation = Quaternion.Euler(targetRotation);*/

    }

    /*public GameObject lens;
    public GameObject pupil;
    public float radius = 2.0f;
    bool blinking = false;
    float c;
    float t=0.1f;

    public void RandomizePupil()
    {
        this.c = 0;
        this.blinking = false;
        Vector2 randompos = Random.insideUnitCircle * radius;
        pupil.transform.localPosition = new Vector3(randompos.x, randompos.y, -0.11f);
    }

    public void Blink()
    {
        this.blinking = true;
        this.lens.SetActive(false);
        this.pupil.SetActive(false);
    }

    public void OpenEyes()
    {
        this.blinking = false;
        this.lens.SetActive(true);
        this.pupil.SetActive(true);
    }

    private void Update()
    {
        if (!blinking)
            return;

        this.c += Time.deltaTime;
        if (this.c > this.t)
        {
            this.c = 0;
            OpenEyes();
        }

    }*/



}
