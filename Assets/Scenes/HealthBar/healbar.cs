using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healbar : MonoBehaviour
{
    public Slider sl;
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        sl.value = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            health++;
            sl.value = health;
            
        }
    }
}
