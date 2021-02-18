using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heartBar : MonoBehaviour
{
    public Image[] hearth;
    public Sprite fullhearth;
    public Sprite emptyhearth;

    public int healths;
    public int numHeals;

    void Update()
    {
        for (int i = 0; i < hearth.Length; i++)
        {
            if (i < healths)
            {
                hearth[i].sprite = fullhearth;
            }
            else 
            {
                hearth[i].sprite = emptyhearth;
            }
            if (i < numHeals)
            {
                hearth[i].enabled=true;
            }
            else
            {
                hearth[i].enabled = false;
            }

        }
    }
}
