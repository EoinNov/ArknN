using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float yPosition;

    public float xDelta;


    bool isStarted;
    bool isMagnetActive;
    
    [Header("Параметры взрыва мяча")]
    public float explodeRadius;
    public bool isExplode;
    public GameObject explodeEffect;
    [Header("Cлед мяча")]
    public TrailRenderer trail;

    [Header("Работа со звуком")]
    //AudioSource audioSource;
    AudioManager AM;
    public AudioClip explodeSoundBall;

    public Pad pad;
    // Start is called before the first frame update
    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
        AM = FindObjectOfType<AudioManager>();
    }
    void Start()
    {
        yPosition = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {


        if (isStarted)
        {
            //Скорость имеет постоянную величину
          rb.velocity=rb.velocity.normalized* speed;
        }
        else
        {
            transform.position = new Vector3(pad.transform.position.x + xDelta, yPosition, 0);
            if (Input.GetMouseButtonDown(0))
            {
                startBall();
            }
        }
        //print(rb.velocity.magnitude);
      


    }
    public void ActivateExplode()
    {
        isExplode = true;
        explodeEffect.SetActive(true);
        trail.startWidth = 0.5f;
        //audioSource.clip = explodeSoundBall;
    }
    public void MultiplySpeed(float speedKoef)
    {
        speed *= speedKoef;

    }
    public void Dublicate()
    {
        ball originalBall = this;

        ball newBall = Instantiate(originalBall);
        newBall.speed = speed;
        newBall.startBall();
        if (isMagnetActive)
        {
            newBall.ActiveMagnet();
        }
    }
    public void ActiveMagnet()
    {
        isMagnetActive = true;
    }
    void startBall()
    {
        float randomX = Random.Range(0, 0);
        Vector2 direction = new Vector2(randomX, 1);
        Vector2 forse = direction.normalized * speed;
        rb.velocity = forse;

       // rb.AddForce(forse * speed);
       
        isStarted = true;
    }
    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.DrawRay(transform.position, rb.velocity);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explodeRadius);
    }
    public void Restart()
    {
        isStarted = false;
        transform.position = new Vector3(pad.transform.position.x+xDelta, yPosition + 2, 0);
        

    }
    void Explode()
    {
        int layerMask = LayerMask.GetMask("block");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explodeRadius, layerMask);
        foreach (Collider2D col in colliders)
        {
            blocks block = col.GetComponent<blocks>();
            if (block == null)
            {
                Destroy(gameObject);
            }
            else
            {
                
                block.DestroyBlock();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //audioSource.Play();
        AM.PlaySound(explodeSoundBall);
        if (isMagnetActive && collision.gameObject.CompareTag("Player"))
        {
            xDelta = transform.position.x-pad.transform.position.x;
            yPosition = transform.position.y;
            Restart();
        }
        if (isExplode && collision.gameObject.CompareTag("block"))
        {
            Explode();
        }
    }




}
