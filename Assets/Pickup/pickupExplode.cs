using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupExplode : MonoBehaviour
{
   void ApplyEffect()
    {
        ball[] balls = FindObjectsOfType<ball>();
        foreach (ball bal in balls)
        {
            bal.ActivateExplode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyEffect();
            Destroy(gameObject);
        }
    }
}
