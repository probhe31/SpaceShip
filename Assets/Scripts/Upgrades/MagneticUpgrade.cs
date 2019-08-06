using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticUpgrade : MonoBehaviour, IUpgrade
{

    /*public float GetRangeMagnetic()
    {
        Dictionary<int, float> prob = new Dictionary<int, float>();
        prob.Add(0, 0.25f);
        prob.Add(1, 0.35f);
        prob.Add(2, 0.5f);

        return prob[(DataMan.Instance.upgradesData.upgrades[(int)eUpgrade.COOKIES_IMAN].Level)];
    }*/

    public void Initialize()
    {
        Dictionary<int, float> prob = new Dictionary<int, float>();
        prob.Add(0, 0.45f);
        prob.Add(1, 0.65f);
        prob.Add(2, 1.1f);

        this.transform.Find("PlayerMagnetic").GetComponent<SphereCollider>().radius = prob[(DataMan.Instance.upgradesData.upgrades[(int)eUpgrade.COOKIES_IMAN].Level)];
    }

    public float GetProbabilityMagnetic()
    {
        Dictionary<int, int> prob = new Dictionary<int, int>();
        prob.Add(0, 20);
        prob.Add(1, 50);
        prob.Add(2, 100);

        return prob[(DataMan.Instance.upgradesData.upgrades[(int)eUpgrade.COOKIES_IMAN].Level)];
    }
}
