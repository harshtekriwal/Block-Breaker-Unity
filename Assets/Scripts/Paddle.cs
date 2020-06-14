using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameter
    [SerializeField] float minXMousePos = 1f;
    [SerializeField] float maxXMousePos = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    
    // Update is called once per frame
   
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minXMousePos, maxXMousePos);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (FindObjectOfType<GameSession>().GetIsAutoplay())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else
        {
            return  Input.mousePosition.x / Screen.width * screenWidthInUnits;

        }
    }
}
 