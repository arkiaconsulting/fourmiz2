namespace MainApp.FSM;

internal sealed class WanderState : FourmizStateBase
{
    private readonly Fourmiz _fourmiz;

    public WanderState(Fourmiz fourmiz) : base()
    {
        _fourmiz = fourmiz;
    }

    public override void Enter()
    {
        _fourmiz.LookWander();
    }

    public override void Execute(double elapsed)
    {
        _fourmiz.Wander();

        _fourmiz.ConsumeEnergy(elapsed, 5);

        if (_fourmiz.IsHungry && _fourmiz.Energy > 0)
        {
            _fourmiz.StateMachine.ChangeState(new SearchForFoodState(_fourmiz));
        }
        else if (_fourmiz.Energy <= 0)
        {
            _fourmiz.StateMachine.ChangeState(new DiedState(_fourmiz));
        }
    }

    public override void Exit() { }
}
