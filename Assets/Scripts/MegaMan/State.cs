
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Player
{
    public abstract class State
    {
        protected MegaManScript player;
        protected StateMachine sm;


        // base constructor
        protected State(MegaManScript player, StateMachine sm)
        {
            this.player = player;
            this.sm = sm;
        }

        // These methods are common to all states
        public virtual void Enter()
        {
            Debug.Log(sm.CurrentState);
        }

        public virtual void HandleInput()
        {
            
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void PhysicsUpdate()
        {
            if (player.joystick.InputDir.x > 0.05)
            {
                player.xv = 4;
                player.sr.flipX = false;
            }
            if (player.joystick.InputDir.x < -0.05)
            {
                player.xv = -4;
                player.sr.flipX = true;
            }
        }

        public virtual void Exit()
        {
        }

    }

}