namespace MainApp.FSM;

internal sealed class DiedState : FourmizStateBase
{
    private readonly Fourmiz _fourmiz;

    public DiedState(Fourmiz fourmiz)
    {
        _fourmiz = fourmiz;
    }

    public override void Enter()
    {
        _fourmiz.LookDead();
    }

    public override void Execute(double elapsed) { }

    public override void Exit() { }
}