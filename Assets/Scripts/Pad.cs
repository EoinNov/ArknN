using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pad : MonoBehaviour
{
    float yPosition;
    public float xMax;
    [Tooltip("Сслыка на мяч")]
    public ball ball;
    [Tooltip("Режим автоматической игры для проверки")]
    public bool autoplay;

    public Gamemanager gm;
    // Start is called before the first frame update
    void Start()
    {
        yPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.pauseActive)
        {
            return;
        }

        if (autoplay)
        {
            Vector3 ballPos = ball.transform.position;
            Vector3 newPadPos = new Vector3(ballPos.x, yPosition, 0);
            newPadPos.x = Mathf.Clamp(newPadPos.x, -xMax, xMax);
            transform.position = newPadPos;
        }
        else
        {
            Vector3 mousePixelPoint = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPoint);
            Vector3 padNewPosition = new Vector3(mouseWorldPosition.x, yPosition, 0);



            padNewPosition.x = Mathf.Clamp(padNewPosition.x, -xMax, xMax);
            //Не работает с физикой
            transform.position = padNewPosition;
        }

       
    }

   
}
