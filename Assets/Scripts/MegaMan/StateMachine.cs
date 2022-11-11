using UnityEngine;


namespace Player
{
    public class StateMachine : MonoBehaviour
    {
        public State CurrentState { get; private set; }
        

        public void Init(State startingState)
        {
            CurrentState = startingState;
            startingState.Enter();
        }

        public void ChangeState(State newState)
        {
            //Debug.Log("Changing state to " + newState);
            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();


        }

        public State GetState()
        {
            return CurrentState;
        }

    }
}