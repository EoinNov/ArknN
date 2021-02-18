using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupScore : MonoBehaviour
{
    public int point;
    // Start is called before the first frame update

    void ApplyEffect()
    {
        Gamemanager gM = FindObjectOfType<Gamemanager>();
        gM.AddScore(point);
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
