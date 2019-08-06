using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BlockElement
{
    float lifeTime = 3;
    float c_lifeTime = 0;
    float speed = 3;
    
    public override void OnInitialize()
    {
        base.OnInitialize();
        this.c_lifeTime = 0;

    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        this.c_lifeTime += Time.deltaTime;
        if (this.c_lifeTime > this.lifeTime)
        {
            this.c_lifeTime = 0;
            this.gameObject.SetActive(false);
        }
    }
    
}
