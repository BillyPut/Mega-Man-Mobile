using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloaterScript : MonoBehaviour
{

    [HideInInspector] public Animator anim;
    public GameObject barrier;

    public bool floated = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void StayInPlace()
    {
        anim.Play("FloaterStay");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && floated == false)
        {
            anim.Play("FloaterFloat");
            barrier.SetActive(true);
            floated = true;
        }
    }


}
