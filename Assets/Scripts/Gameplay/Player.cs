using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public RedLightSensor redLightSensor;
    public CookieSensor cookieSensor;
    public LotCookieSensor lotCookieSensor;
    public DieDetection dieDetection;
    public PlayerMovement playerMovement;
    public PlayerInput input;


    public void Die()
    {
        this.playerMovement.OnDie();
        this.lotCookieSensor.enabled = false;
        this.cookieSensor.enabled = false;
        this.redLightSensor.enabled = false;
        this.input.enabled = false;
        this.dieDetection.enabled = false;
    }

    public void Traslate(Vector3 respawnPosition)
    {
        this.playerMovement.Traslate(respawnPosition);
    }

    public void Respawn(Vector3 respawnPosition)
    {
        this.playerMovement.OnRespawn(respawnPosition);
        this.lotCookieSensor.enabled = true;
        this.cookieSensor.enabled = true;
        this.redLightSensor.enabled = true;
        this.input.enabled = true;
        this.dieDetection.isDie = false;
        this.dieDetection.enabled = true;
    }
}
