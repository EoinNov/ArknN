using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSpeed : MonoBehaviour
{
    public float koofSpeed;
    // Start is called before the first frame update
    void ApplyEffect()
    {
        ball[] balls = FindObjectsOfType<ball>();
        foreach (ball bal in balls)
            {
            bal.MultiplySpeed(koofSpeed);
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
