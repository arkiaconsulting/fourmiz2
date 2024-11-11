namespace MainApp.FSM;

internal abstract class FourmizStateBase
{
    public abstract void Enter();
    public abstract void Execute(double elapsed);
    public abstract void Exit();
}
