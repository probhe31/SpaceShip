using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieFactory : Factory
{
    string namePattern;


    public CookieFactory(LevelGenerator _levelGenerator, GameWeights _gameWeights) : base(_levelGenerator, _gameWeights)
    {

    }


    public BlockElement Create(int meters, Block block)
    {
        if (Random.Range(0, 200) < 50 && meters > 1)
        {
            namePattern = "cookie_pattern_1";
            if (Random.Range(0, 100) < 40)
            {
                namePattern = "cookie_pattern_1";
            }
            else
            {
                namePattern = "cookie_pattern_2";
            }


            GameObject pattern = TrashMan.spawn(namePattern, block.transform.position);

            if (pattern)
            {
                int rot = Random.Range(1, 5);
                switch (rot)
                {
                    case 1:
                        pattern.transform.localEulerAngles = new Vector3(0, 0, 0);
                        break;
                    case 2:
                        pattern.transform.localEulerAngles = new Vector3(0, 90, 0);
                        break;
                    case 3:
                        pattern.transform.localEulerAngles = new Vector3(0, 270, 0);
                        break;
                    case 4:
                        pattern.transform.localEulerAngles = new Vector3(0, 180, 0);
                        break;
                }

                pattern.GetComponent<Pattern>().Initialize(block);
                return pattern.GetComponent<BlockElement>();
            }
            else
            {
                Debug.LogError("no pudimos crear un cookie pattern");
                return null;
            }

        }
        return null;
    }
}
