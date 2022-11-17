using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterScript : Enemies
{
    [HideInInspector] public BoxCollider2D box;
    [HideInInspector] public Animator anim;

    public Rigidbody2D bullet;

    public float switchTimer;
    public float shootDirection;

    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();

        hp = 1;
        attackDamage = 1;
        scoreValue = 300;

        switchTimer = 3f;

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
        }
    }

    public void InvincibleMode()
    {
        anim.Play("BlasterInvincible", 0, 0);
        invincible = true;
    }

    public void VincibleMode()
    {
        anim.Play("BlasterVincible", 0, 0);
        invincible = false;
        StartCoroutine(ShootBullets());
    }

    IEnumerator ShootBullets()
    {
        
        for (float i = 0;i < 4; i++)
        {
            yield return new WaitForSeconds(0.7f);

            float xPos = transform.position.x;
            float yPos = transform.position.y;

            Rigidbody2D bulletProj = Instantiate(bullet, new Vector3(xPos - 0.6f, yPos + 0.4f, 0), Quaternion.identity);
            if (i == 0)
            {
                bulletProj.velocity = new Vector2(shootDirection, Random.Range(4.0f, 5.0f));
            }
            if (i == 1)
            {
                bulletProj.velocity = new Vector2(shootDirection, Random.Range(0.5f, 1.0f));
            }
            if (i == 2)
            {
                bulletProj.velocity = new Vector2(shootDirection, Random.Range(-1.0f, 0f));
            }
            if (i == 3)
            {
                bulletProj.velocity = new Vector2(shootDirection, Random.Range(-4.5f, -5.5f));
            }

               
        }

        switchTimer = 3f;
        InvincibleMode();

    }

}
