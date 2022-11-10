
using UnityEngine;
namespace Player
{
    public class RunningState : State
    {


        // constructor
        public RunningState(MegaManScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            //player.anim.Play("megaIdle", 0, 0);
            

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

            player.CheckForIdle();
            player.CheckForShoot();
            player.CheckForJump();


        }

        public override void PhysicsUpdate()
        {
            if (player.joystick.InputDir.x > 0.05)
            {
                player.xv = 2;
            }
            if (player.joystick.InputDir.x < -0.05)
            {
                player.xv = -2;
            }

            base.PhysicsUpdate();
        }
    }
}
