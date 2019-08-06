using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball2 : MonoBehaviour
{
    public Transform spawningPoint;
    public GameObject prefabBall;
    Ball currentBall;

    private void Start()
    {
        //CreateBall(new vec);
    }

    public void CreateBall(Vector3 pos)
    {
        GameObject cook = GameObject.Instantiate(prefabBall, pos, Quaternion.Euler(new Vector3(-90,0,0)));
        //cook.GetComponent<Ball>().Initialize();
        currentBall = cook.GetComponent<Ball>();
        currentBall.Initialize();
    }

    public void Throw(Vector3 force)
    {
        if (!currentBall)
            return;

        currentBall.Throw(force);
    }

    Vector3 initPos;
    Vector3 endPos;

    public void Update()
    {

        /*if (Input.GetKey(KeyCode.P))
        {
            Game.Instance.AddPoint(1);
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            //currentBall = null;
            initPos = Input.mousePosition;
            initPos.z = 10.0f;
            initPos = Camera.main.ScreenToWorldPoint(initPos);


            CreateBall(initPos);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            endPos.z = 10.0f;
            endPos = Camera.main.ScreenToWorldPoint(endPos);



            Vector3 force = new Vector3();
            force.z = 900.0f;
            force.y = (endPos.y - initPos.y) * 180.0f;
            force.x = (endPos.x - initPos.x) * 100.0f;
            Throw(force);
        }
    }
}
