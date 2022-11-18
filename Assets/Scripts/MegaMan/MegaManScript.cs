using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


namespace Player
{ 

    public class MegaManScript : MonoBehaviour
    {

        [HideInInspector] public Rigidbody2D rb;
        [HideInInspector] public Animator anim;
        [HideInInspector] public SpriteRenderer sr;

        public LayerMask platformLayerMask;
        bool rayHit;

        public JoybuttonScript jumpButton;
        public JoybuttonScript shootButton;
        public JoystickScript joystick;

        public Rigidbody2D pellet;
        
        //public float xv, yv;
        public float cooldown;
        public float shootAnimTimer;
        public float invinsibility;
        public float yOffset;
        public bool hit, fellOff;

        public IdleState idleState;
        public JumpingState jumpingState;
        public IdleShootState idleShootState;
        public RunningState runningState;
        public RunningShootState runningShootState;
        public FallingState fallingstate;
        public AirShootState airShootState;
        public HitState hitState;

        [HideInInspector] public StateMachine sm;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>(); 
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            sm = gameObject.AddComponent<StateMachine>();

            idleState = new IdleState(this, sm);
            jumpingState = new JumpingState(this, sm);
            idleShootState = new IdleShootState(this, sm);
            runningState = new RunningState(this, sm);
            runningShootState = new RunningShootState(this, sm);
            airShootState = new AirShootState(this, sm);
            fallingstate = new FallingState(this, sm);
            hitState = new HitState(this, sm);   

            sm.Init(idleState);
        }

        // Update is called once per frame
        void Update()
        {
  
            RaycastCheck();

            cooldown -= Time.deltaTime;
            shootAnimTimer -= Time.deltaTime;
            invinsibility -= Time.deltaTime;

            sm.CurrentState.HandleInput();
            sm.CurrentState.LogicUpdate();

            if (rayHit == true)
            {
                yOffset = 0.8f;
            }
            else
            {
                yOffset = 1.1f;
            }

        }

        void FixedUpdate()
        {
           
            sm.CurrentState.PhysicsUpdate();
           
        }

        public void CheckForRun()
        {

            
            if (joystick.InputDir.x > 0.1 && rayHit == true || joystick.InputDir.x < -0.1 && rayHit == true)
            {
                sm.ChangeState(runningState);
         
            }
            
        }

        public void CheckForIdle()
        {
            if (joystick.InputDir.x < 0.05 && joystick.InputDir.x > -0.05 && rayHit == true)
            {
                sm.ChangeState(idleState);
            }
        }

        public void CheckForJump()
        {
            if (jumpButton.isPressing == true && rayHit == true)
            {
                sm.ChangeState(jumpingState);
            }
        }

        public void CheckForFall()
        {
            if (rayHit == false)
            {
                sm.ChangeState(fallingstate);
            }
        }

        public void CheckForShoot()
        {
            float xPos = transform.position.x;
            float yPos = transform.position.y;

            if (shootButton.isPressing == true && cooldown <= 0)
            {
                if (sr.flipX == false)
                {
                    Rigidbody2D proj = Instantiate(pellet, new Vector3(xPos + 0.8f, yPos + yOffset, 0), Quaternion.identity);
                    proj.velocity = transform.right * 10;
                }
                else
                {
                    Rigidbody2D proj = Instantiate(pellet, new Vector3(xPos - 0.8f, yPos + yOffset, 0), Quaternion.identity);
                    proj.velocity = -transform.right * 10;
                }

                if (rayHit == true && rb.velocity.x == 0)
                {
                    sm.ChangeState(idleShootState);
                }
                if (rayHit == true && rb.velocity.x != 0)
                {
                    sm.ChangeState(runningShootState);
                }
                if (rayHit == false)
                {
                    sm.ChangeState(airShootState);
                }

            }
        }

        public void CheckForHit()
        {
            if (hit == true)
            {
                StartCoroutine(FlashWhite());
                sm.ChangeState(hitState);
            }
        }

        public void RaycastCheck()
        {
            int layerMask = LayerMask.GetMask("Platform");

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x - 0.2f, transform.position.y), -Vector2.up, 0.2f, layerMask);
            RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x - 0.75f, transform.position.y), -Vector2.up, 0.2f, layerMask);
            RaycastHit2D hit3 = Physics2D.Raycast(new Vector2(transform.position.x + 0.4f, transform.position.y), -Vector2.up, 0.2f, layerMask);
            Color hitColor = Color.yellow;
            rayHit = false;

            if (hit.collider != null || hit2.collider != null || hit3.collider != null)
            {
                hitColor = Color.green;
                Debug.DrawRay(new Vector2(transform.position.x - 0.2f, transform.position.y), -Vector2.up * 0.2f, hitColor);
                Debug.DrawRay(new Vector2(transform.position.x - 0.75f, transform.position.y), -Vector2.up * 0.2f, hitColor);
                Debug.DrawRay(new Vector2(transform.position.x + 0.4f, transform.position.y), -Vector2.up * 0.2f, hitColor);
                rayHit = true;
            }


        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy" && invinsibility <= 0 || collision.gameObject.tag == "EnemyBullet" && invinsibility <= 0)
            {
                hit = true;
            }
            if (collision.gameObject.tag == "DeathPlane")
            {
                fellOff = true;
            }
        }

        IEnumerator FlashWhite()
        {

            for (int n = 0; n < 3; n++)
            {
                yield return new WaitForSeconds(0.2f);
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                yield return new WaitForSeconds(0.2f);
                GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

            }

        }
    }

}


