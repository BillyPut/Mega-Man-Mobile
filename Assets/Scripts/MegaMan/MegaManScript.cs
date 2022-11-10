using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{ 

    public class MegaManScript : MonoBehaviour
    {

        public Rigidbody2D rb;
        public Animator anim;
        SpriteRenderer sr;
        public JoybuttonScript jumpButton;
        public JoybuttonScript shootButton;
        public JoystickScript joystick;
        
        public float xv, yv;
        public bool right = true;
       
        public IdleState idleState;
        public JumpingState jumpingState;
        public IdleShootState idleShootState;
        public RunningState runningState;
        //public RunningShootState runningShootState;
        //public FallingState fallingstate;
        //public AirShootState airShootState;

        public StateMachine sm;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            sm = gameObject.AddComponent<StateMachine>();

            idleState = new IdleState(this, sm);
            //jumpingState = new JumpingState(this, sm);
            //idleShootState = new IdleShootState(this, sm);
            runningState = new RunningState(this, sm);


            sm.Init(idleState);
        }

        // Update is called once per frame
        void Update()
        {
            rb.velocity = new Vector2(xv, yv);
        
        }

        public void CheckForRun()
        {
            if (joystick.InputDir.x != 0)
            {
                sm.ChangeState(runningState);
         
            }
            
        }

        public void CheckForIdle()
        {
            if (joystick.InputDir.x == 0)
            {
                sm.ChangeState(idleState);
            }
        }

        public void CheckForJump()
        {
            if (jumpButton.isPressing == true)
            {
                //sm.ChangeState(jumpingState);
            }
        }

        public void CheckForShoot()
        {
            if (shootButton.isPressing == true)
            {
                
            }
        }





    }

}


