using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAnimation : MonoBehaviour
{
    public ParticleSystem boomPS;
    public ParticleSystem speedPS;


    public void OnDie()
    {
        boomPS.transform.position = this.transform.position;
        boomPS.gameObject.SetActive(true);
        boomPS.Play();
        speedPS.gameObject.SetActive(false);
    }
}
