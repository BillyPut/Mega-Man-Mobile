using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletScript : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
