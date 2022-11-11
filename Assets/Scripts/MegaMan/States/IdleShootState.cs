
using UnityEngine;
namespace Player
{
    public class IdleShootState : State
    {


        // constructor
        public IdleShootState(MegaManScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.Play("megaStandShoot", 0, 0);
            player.shootAnimTimer = 0.3f;
            player.xv = 0;
            player.cooldown = 0.2f;
            


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


            if (player.shootAnimTimer <= 0f)
            {
                player.CheckForIdle();
            }
            player.CheckForJump();
            player.CheckForRun();
            player.CheckForHit();


        }

        public override void PhysicsUpdate()
        {
            //base.PhysicsUpdate();
        }
    }
}
