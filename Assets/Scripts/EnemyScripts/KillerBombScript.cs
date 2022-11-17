using Player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillerBombScript : Enemies
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public BoxCollider2D box;

    [HideInInspector] bool start;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();

        hp = 1;
        attackDamage = 3;
        scoreValue = 800;
    }

    // Update is called once per frame
    void Update()
    {
        Activate();
        Deactivate();

        
        if (start == false && box.isActiveAndEnabled == true)
        {
            StartCoroutine(UpandDown());
            start = true;
        }
      
    }

    IEnumerator UpandDown()
    {
        while(true)
        {
          
            
            rb.velocity = new Vector2(-3f, 5f);
                      
            yield return new WaitForSeconds(0.9f);

            rb.velocity = new Vector2(-3f, -5f);
            
            yield return new WaitForSeconds(0.9f);



        }
        
    }
}
