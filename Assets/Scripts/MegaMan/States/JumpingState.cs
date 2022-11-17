
using UnityEngine;
namespace Player
{
    public class JumpingState : State
    {


        // constructor
        public JumpingState(MegaManScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.Play("megaFall", 0, 0);
            player.rb.velocity = Vector2.up * 11f;
            


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


            player.CheckForShoot();
            player.CheckForFall();
            player.CheckForHit();



        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
