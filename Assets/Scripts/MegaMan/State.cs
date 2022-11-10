
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
            //Debug.Log("This is base.enter");
        }

        public virtual void HandleInput()
        {
            
        }

        public virtual void LogicUpdate()
        {
        }

        public virtual void PhysicsUpdate()
        {
        }

        public virtual void Exit()
        {
        }

    }

}