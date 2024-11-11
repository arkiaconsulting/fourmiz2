namespace MainApp.FSM;

internal sealed class EatState : FourmizStateBase
{
    private readonly Fourmiz _fourmiz;
    private readonly FoodSpot _foodSpot;

    public EatState(Fourmiz fourmiz, FoodSpot foodSpot) : base()
    {
        _fourmiz = fourmiz;
        _foodSpot = foodSpot;
    }

    public override void Enter()
    {
        _fourmiz.LookEating();
        _fourmiz.Stop();
    }

    public override void Execute(double elapsed)
    {
        _fourmiz.Eat(_foodSpot, elapsed);

        if (_fourmiz.IsRepleted)
        {
            _fourmiz.StateMachine.ChangeState(new WanderState(_fourmiz));
        }
        else if (_foodSpot.IsDepleted)
        {
            _fourmiz.StateMachine.ChangeState(new SearchForFoodState(_fourmiz));
        }
    }

    public override void Exit() { }
}
