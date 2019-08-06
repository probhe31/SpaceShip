using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccumulatorMan : MonoBehaviour
{
    public static AccumulatorMan Instance;
    public Accumulator redLights;
    public Accumulator explosives;

    private void Awake()
    {
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }


    private void Start()
    {
        redLights = new Accumulator(new RedLightSerializable());
        explosives = new Accumulator(new ExplosivesSerializable());
        EventsMan.OnNewGameStart += OnNewGameStart;
    }

    void OnNewGameStart()
    {
        this.redLights.AmountThisGame = 0;
        this.explosives.AmountThisGame = 0;
    }
   
}
