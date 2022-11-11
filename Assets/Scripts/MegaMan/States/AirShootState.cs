
using UnityEngine;
namespace Player
{
    public class AirShootState : State
    {


        // constructor
        public AirShootState(MegaManScript player, StateMachine sm) : base(player, sm)
        {
        }

        public override void Enter()
        {
            base.Enter();
            player.anim.Play("megaAirShoot", 0, 0);
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
            if (player.shootAnimTimer <= 0)
            {
                player.CheckForFall();
            }    
            player.CheckForRun();
            player.CheckForHit();


        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }
    }
}
