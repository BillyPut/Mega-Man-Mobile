
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
namespace Player
{
    public class RunningShootState : State
    {


        // constructor
        public RunningShootState(MegaManScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.Play("megaShootState", 0, 0);
            player.shootAnimTimer = 0.3f;
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



            player.CheckForIdle();
            player.CheckForJump();
            player.CheckForFall();
            if (player.shootAnimTimer <= 0 )
            {
                player.CheckForRun();
            }
            player.CheckForHit();


        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
