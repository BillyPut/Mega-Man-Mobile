using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    public GameManager gameManager;
    

    public int attackDamage;
    public float explodeTimer;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        explodeTimer -= Time.deltaTime;
        if (explodeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && gameManager.playerHittable == true)
        {
            gameManager.health -= attackDamage;
        }
    }
}
