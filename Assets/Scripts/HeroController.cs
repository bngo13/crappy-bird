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
    private Boolean isFacingLeft = true;
    
    // Animations
    private Animator heroAnimation;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        heroAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        heroAnimation.SetFloat("flapSpeed", horizontalSpeed);
        
        
        body.AddForce(new Vector2((horizontalSpeed * maxHorizAccel), Mathf.Abs(horizontalSpeed * maxVerticalAccel)));
        
        if ((horizontalSpeed > 0 && isFacingLeft) || (horizontalSpeed < 0 && !isFacingLeft))
        {
            FlipImage();
        }
        
        yAccel += 0.025f;
    }

    void FlipImage()
    {
        isFacingLeft = !isFacingLeft;
        var flipped = transform.localScale;
        flipped.x *= -1;
        transform.localScale = flipped;

    }
}
