using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterScript : Enemies
{
    [HideInInspector] public BoxCollider2D box;
    [HideInInspector] public Animator anim;

    public Rigidbody2D bullet;

    public float switchTimer;

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
        for (int i = 0;i < 4; i++)
        {
            float xPos = transform.position.x;
            float yPos = transform.position.y;

            Rigidbody2D bulletProj = Instantiate(bullet, new Vector3(xPos - 0.6f, yPos + 0.4f, 0), Quaternion.identity);
            bulletProj.velocity = new Vector2(-6, Random.Range(-4.0f, 4.0f));

            yield return new WaitForSeconds(0.5f);
        }

        switchTimer = 3f;
        InvincibleMode();

    }

}
