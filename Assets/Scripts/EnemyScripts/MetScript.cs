using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetScript : Enemies
{
    [HideInInspector] public BoxCollider2D box;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();

        hp = 1;
        attackDamage = 1;
        scoreValue = 500;
    }

    // Update is called once per frame
    void Update()
    {
        Activate();
        Deactivate();
    }
}
