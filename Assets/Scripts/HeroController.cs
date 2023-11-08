using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private Rigidbody2D body;
    private float yAccel = 2.5f;
    [SerializeField] private float maxVerticalAccel = 10f;
    [SerializeField] private float maxHorizAccel = 2f;
    private Boolean facingLeft = true;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xLoc = Input.GetAxis("Horizontal");   
        body.AddForce(new Vector2((xLoc * maxHorizAccel), Mathf.Abs(xLoc * maxVerticalAccel)));
        
        if ((xLoc > 0 && facingLeft) || (xLoc < 0 && !facingLeft))
        {
            FlipImage();
        }
        
        yAccel += 0.025f;
    }

    void FlipImage()
    {
        facingLeft = !facingLeft;
        var flipped = transform.localScale;
        flipped.x *= -1;
        transform.localScale = flipped;

    }
}
