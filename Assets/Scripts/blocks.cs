using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
    [Tooltip("Очки за блок")]
    public int points;
    [Tooltip("Игровая логика")]
    public Gamemanager gamemanager;
    public LevelChanger lc;

    public SpriteRenderer sRender;

    public bool invisible;

    [Tooltip("Префабы и эффекты")]
    public GameObject pickupPrefab;
    public GameObject particleEffectPrefab;

    [Header("Explode")]
    public bool explosive;
    public float explosiveRadius;

    [Header("sound")]
    public AudioClip sndDestroy;
    AudioManager AM;


    private void Awake()
    {
        AM = FindObjectOfType<AudioManager>();
    }
    private void Start()
    {
        gamemanager = FindObjectOfType<Gamemanager>();
        lc = FindObjectOfType<LevelChanger>();
        lc.BlockCreated();
        if (invisible)
        {
            sRender = GetComponent<SpriteRenderer>();
            sRender.enabled = false;
        }
    }
   
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (invisible)
        {
            sRender.enabled = true;
            invisible = false;
            return;
            


        }
        DestroyBlock();
        

    }
    public void DestroyBlock()
    {
        AM.PlaySound(sndDestroy);
        lc.BlockDestroyed();
        gamemanager.AddScore(points);

        Destroy(gameObject);

        Instantiate(pickupPrefab,transform.position,Quaternion.identity);
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);

        Exsplode();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosiveRadius);

    }

    private void Exsplode()
    {
        int layerMask = LayerMask.GetMask("blocks");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosiveRadius, layerMask);
        foreach (Collider2D col in colliders)
        {
            blocks block = col.GetComponent<blocks>();

            if (block == null)
            {
                Destroy(col.gameObject);
            }
            else
            {
                block.DestroyBlock();
            }

          
        }
    }
}
