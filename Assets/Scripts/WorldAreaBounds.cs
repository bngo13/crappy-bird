using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldAreaBounds : MonoBehaviour
{
    private AudioSource Source;
    [SerializeField] private AudioClip explosionSound;
    [SerializeField] private GameObject explosionSprite;
    
    private float worldXDist;
    private float worldYDist;

    void Start()
    {
        
        worldYDist = Camera.main.orthographicSize;
        worldXDist = worldYDist * Screen.width / Screen.height;
        
        Source = this.GetComponent<AudioSource>();
        Source.clip = explosionSound;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        var clampedPosition = other.transform.position;
        const int buffer = 1;
        var x = Mathf.Clamp(clampedPosition.x, -worldXDist+buffer, worldXDist-buffer);
        var y = Mathf.Clamp(clampedPosition.y, -worldYDist+buffer, worldYDist-buffer);
        clampedPosition = new Vector3(x, y, clampedPosition.z);
        
        var explodingObject = Instantiate(explosionSprite, clampedPosition, Quaternion.identity);
        var explodeAnimator = explodingObject.GetComponent<Animator>();
        
        Destroy(other.gameObject);
        Destroy(explodingObject, explodeAnimator.runtimeAnimatorController.animationClips[0].length);
        Source.Play();

    }
}
