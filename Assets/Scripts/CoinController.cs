using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private int lifetime;

    private GameController game;

    // Start is called before the first frame update
    void Start()
    {
        var gameObj = GameObject.FindGameObjectWithTag("GameController");
        game = gameObj.GetComponent<GameController>();
        Destroy(this.gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        game.IncrementScore();
        Destroy(this.gameObject);
    }
}
