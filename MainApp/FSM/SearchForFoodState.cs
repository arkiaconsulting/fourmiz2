namespace MainApp.FSM;

internal sealed class SearchForFoodState : FourmizStateBase
{
    private readonly Fourmiz _fourmiz;

    public SearchForFoodState(Fourmiz fourmiz) : base()
    {
        _fourmiz = fourmiz;
    }

    public override void Enter()
    {
        _fourmiz.LookSearchingForFood();
    }

    public override void Execute(double elapsed)
    {
        _fourmiz.Wander();
        var foodSpot = _fourmiz.SearchForFood();

        _fourmiz.ConsumeEnergy(elapsed, 10);

        if (_fourmiz.Energy <= 0)
        {
            _fourmiz.StateMachine.ChangeState(new DiedState(_fourmiz));
        }

        if (foodSpot != null)
        {
            _fourmiz.StateMachine.ChangeState(new HeadToFoodSpotState(_fourmiz, foodSpot));
        }
    }

    public override void Exit() { }
}
