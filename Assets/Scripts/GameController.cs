using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject coinSprite;
    [SerializeField] private float maxCoinDistance = 5f;
    [SerializeField] private float waitTime = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnCoin()
    {
        var position = new Vector2(Random.Range(-maxCoinDistance, maxCoinDistance),Random.Range(-maxCoinDistance, maxCoinDistance));
        Instantiate(coinSprite, position, Quaternion.identity);
        
    }

    private IEnumerator SpawnCoins()
    {
        while (true)
        {
            SpawnCoin();
            yield return new WaitForSeconds(waitTime);
        }
    }
}
