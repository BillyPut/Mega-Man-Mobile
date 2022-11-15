
using Unity.VisualScripting;
using UnityEngine;
namespace Player
{
    public class HitState : State
    {


        // constructor
        public HitState(MegaManScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.Play("megaHit", 0, 0);
            player.invinsibility = 0.3f;
            player.rb.velocity = new Vector2(0f, 0f);
            


        }

        public override void Exit()
        {
            base.Exit();
            player.hit = false;

        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();


            if (player.invinsibility <= 0)
            {
                player.CheckForRun();
                player.CheckForIdle();
                player.CheckForJump();
                player.CheckForFall();
            }
     


        }

        public override void PhysicsUpdate()
        {
            //base.PhysicsUpdate();
        }
    }
}
