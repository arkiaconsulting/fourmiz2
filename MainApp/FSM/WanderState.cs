namespace MainApp.FSM;

internal sealed class WanderState : FourmizStateBase
{
    private readonly Fourmiz _fourmiz;

    public WanderState(Fourmiz fourmiz) : base()
    {
        _fourmiz = fourmiz;
    }

    public override void Enter() { }

    public override void Execute(double elapsed)
    {
        _fourmiz.Wander();

        _fourmiz.ConsumeEnergy(elapsed, 10);

        if (_fourmiz.Energy <= 0)
        {
            _fourmiz.StateMachine.ChangeState(new DiedState(_fourmiz));
        }
    }

    public override void Exit() { }
}
