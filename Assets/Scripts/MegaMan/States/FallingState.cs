
using UnityEngine;
namespace Player
{
    public class FallingState : State
    {


        // constructor
        public FallingState(MegaManScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.Play("megaFall", 0, 0);
            


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
            player.CheckForRun();
            player.CheckForIdle();
            player.CheckForHit();



        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
