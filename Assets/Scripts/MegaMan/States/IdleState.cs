
using UnityEngine;
namespace Player
{
    public class IdleState : State
    {


        // constructor
        public IdleState(MegaManScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.Play("megaIdle", 0, 0);
            player.xv = 0;
           

        }

        public override void Exit()
        {
            base.Exit();


        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

          
      
            player.CheckForRun();
            player.CheckForShoot();
            player.CheckForJump();
            player.CheckForHit();
           

        }

        public override void PhysicsUpdate()
        {
            //base.PhysicsUpdate();
        }
    }
}
