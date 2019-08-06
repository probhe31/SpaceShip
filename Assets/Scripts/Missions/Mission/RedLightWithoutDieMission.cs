using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLightWithoutDieMission : Mission
{
    int lights = 0;

    public override void OnAddMission()
    {
    }

    public override void AddEvents()
    {
        throw new System.NotImplementedException();
    }

    public override void RemoveEvents()
    {
        throw new System.NotImplementedException();
    }



    public RedLightWithoutDieMission(int _lights) : base()
    {
        this.localizedKey = "lightMissionNoDie";
        this.lights = _lights;
    }

    

    public override string GetString()
    {
        throw new System.NotImplementedException();
    }

    public override void OnMissionComplete()
    {
        throw new System.NotImplementedException();
    }
}
