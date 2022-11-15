using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public int hp;
    public int attackDamage;
    public int scoreValue;
    public GameObject player;
    public MegaManScript playerValue;
    public GameManager gameManager;

    public void Activate()
    {
        float dist = player.transform.position.x - gameObject.transform.position.x;
        if (dist < 0f && dist > -18f)
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

  
}
