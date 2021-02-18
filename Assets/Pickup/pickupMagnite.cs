using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupMagnite : MonoBehaviour
{
    // Start is called before the first frame update
    void ApplyEffect()
    {
        ball balls = FindObjectOfType<ball>();
        balls.ActiveMagnet();
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
