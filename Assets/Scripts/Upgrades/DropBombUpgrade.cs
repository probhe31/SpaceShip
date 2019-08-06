using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropBombUpgrade : MonoBehaviour, IUpgrade
{
    float coldown = 3;
    float c_coldown = 0;
    bool recharching = false;
    bool canDrop = false;
    Button bombButton;

    public void Initialize(GameObject button)
    {
        switch (DataMan.Instance.upgradesData.upgrades[(int)eUpgrade.BOMB].Level)
        {
            case 0:
                coldown = 10;
                break;
            case 1:
                coldown = 8;
                break;
            case 2:
                coldown = 5;
                break;
        }

        canDrop = true;
        bombButton = button.GetComponent<Button>();
        bombButton.onClick.AddListener(Drop);
    }


    void Update()
    {
        if (recharching)
        {
            this.c_coldown += Time.deltaTime;
            if (this.c_coldown > coldown)
            {
                this.c_coldown = 0;
                this.recharching = false;
                this.canDrop = true;
                bombButton.interactable = true;
            }
        }
    }

   

    public void Drop()
    {
        if (!canDrop)
            return;

        this.canDrop = false;
        this.recharching = true;
        this.c_coldown = 0;
        GameObject bomb = TrashMan.spawn("bomb", Game.Instance.player.transform.position+Vector3.down*2);

        bombButton.interactable = false;
    }
}
