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
        
        public float xv, yv;
        public int health;
        public float cooldown;
        public float shootAnimTimer;
        public float invinsibility;
        public bool hit;

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

            health = 100;

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

           

        }

        void FixedUpdate()
        {
            if (rayHit == false)
            {
                yv -= Time.deltaTime * 6f;
            }
            if (rayHit == true && yv < -0.01)
            {
                yv = 0;
            }
           
            rb.velocity = new Vector2(xv, yv);
            sm.CurrentState.PhysicsUpdate();
           
        }

        public void CheckForRun()
        {

            
            if (joystick.InputDir.x > 0.1 || joystick.InputDir.x < -0.1 && rayHit == true)
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
                    Rigidbody2D proj = Instantiate(pellet, new Vector3(xPos + 0.8f, yPos + 0.8f, 0), Quaternion.identity);
                    proj.velocity = transform.right * 10;
                }
                else
                {
                    Rigidbody2D proj = Instantiate(pellet, new Vector3(xPos - 0.8f, yPos + 0.8f, 0), Quaternion.identity);
                    proj.velocity = -transform.right * 10;
                }

                if (rayHit == true && xv == 0)
                {
                    sm.ChangeState(idleShootState);
                }
                if (rayHit == true && xv != 0)
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
                sm.ChangeState(hitState);
            }
        }

        public void RaycastCheck()
        {
            int layerMask = LayerMask.GetMask("Platform");

            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, 0.2f, layerMask);
            Color hitColor = Color.yellow;
            rayHit = false;

            if (hit.collider != null)
            {
                hitColor = Color.green;
                Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), -Vector2.up * 0.2f, hitColor);
                rayHit = true;
            }

            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), -Vector2.up * 0.2f, hitColor);

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy" && invinsibility <= 0)
            {
                hit = true;
            }
        }

    }

}


