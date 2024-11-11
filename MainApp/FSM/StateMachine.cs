namespace MainApp.FSM;

internal sealed class StateMachine
{
    public FourmizStateBase CurrentState => _currentState;

    private FourmizStateBase _currentState;

    public StateMachine(FourmizStateBase initialState)
    {
        _currentState = initialState;
    }

    public void SetCurrentState(FourmizStateBase state)
    {
        _currentState = state;
    }

    public void Update(double elapsed)
    {
        _currentState.Execute(elapsed);
    }

    public void ChangeState(FourmizStateBase newState)
    {
        _currentState.Exit();

        _currentState = newState;

        _currentState.Enter();
    }
}
