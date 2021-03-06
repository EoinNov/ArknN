﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public ball ball;
    public Gamemanager gm;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<ball>();
        gm = FindObjectOfType<Gamemanager>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("ball"))
        {
            ball.Restart();
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
