using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillerBombScript : Enemies
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

        hp = 1;
        attackDamage = 3;
        scoreValue = 800;

        StartCoroutine(UpandDown());

    }

    // Update is called once per frame
    void Update()
    {
        Activate();
        Deactivate();
      
    }

    IEnumerator UpandDown()
    {
        while(true)
        {
            if (box.isActiveAndEnabled)
            {
                rb.velocity = new Vector2(-3f, 5f);
            }
          
            yield return new WaitForSeconds(0.9f);

            if (box.isActiveAndEnabled)
            {
                rb.velocity = new Vector2(-3f, -5f);
            }

            yield return new WaitForSeconds(0.9f);



        }
        
    }
}
