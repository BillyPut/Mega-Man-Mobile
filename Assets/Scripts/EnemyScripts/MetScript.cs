using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetScript : Enemies
{
    [HideInInspector] public BoxCollider2D box;
    [HideInInspector] public Animator anim;

    public Rigidbody2D bullet;

    public float switchTimer, bulletTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        hp = 1;
        attackDamage = 1;
        scoreValue = 300;

        switchTimer = 2.5f;
        bulletTimer = 0.5f;


        InvincibleMode();
    }

    // Update is called once per frame
    void Update()
    {
        Activate();
        Deactivate();

        if (box.isActiveAndEnabled)
        {
            switchTimer -= Time.deltaTime;
        }

        if (invincible == true && switchTimer <= 0)
        {
            VincibleMode();
            switchTimer = 3f;
        }

        if (invincible == false)
        {
            bulletTimer -= Time.deltaTime;

            if (switchTimer <= 0)
            {
                InvincibleMode();
                switchTimer = 2f;
            }
            if (bulletTimer <= 0)
            {
                ShootBullets();
                bulletTimer = 3f;
            }
           
        }
    }

    public void InvincibleMode()
    {
        anim.Play("MetInvincible", 0, 0);
        invincible = true;
    }

    public void VincibleMode()
    {
        anim.Play("MetVincible", 0, 0);
        invincible = false;
        bulletTimer = 0.5f;
    }

    public void ShootBullets()
    {
        float xPos = transform.position.x;
        float yPos = transform.position.y;

        Rigidbody2D bulletProj = Instantiate(bullet, new Vector3(xPos - 0.6f, yPos + 0.4f, 0), Quaternion.identity);
        Rigidbody2D bulletProj2 = Instantiate(bullet, new Vector3(xPos - 0.6f, yPos + 0.4f, 0), Quaternion.identity);
        Rigidbody2D bulletProj3 = Instantiate(bullet, new Vector3(xPos - 0.6f, yPos + 0.4f, 0), Quaternion.identity);
        bulletProj.velocity = -transform.right * 5;
        bulletProj2.velocity = new Vector2(-4f, 2);
        bulletProj3.velocity = new Vector2(-4f, -2);
    }

}
