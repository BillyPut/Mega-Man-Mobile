using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int hp;
    public int attackDamage;
    public int scoreValue;
    public bool invincible = false;
    public GameObject player;
    public GameManager gameManager;

    public void Activate()
    {
        float dist = player.transform.position.x - gameObject.transform.position.x;
        if (dist < 0f && dist > -14f)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

    }

    public void Deactivate()
    {
        float dist = player.transform.position.x - gameObject.transform.position.x;
        if (dist > 36f)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pellet" && invincible == false)
        {
            gameManager.score += scoreValue;
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player" && gameManager.playerHittable == true)
        {
            gameManager.health -= attackDamage;
        }
    }
}
