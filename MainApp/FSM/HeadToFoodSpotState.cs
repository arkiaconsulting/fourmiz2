using Silk.NET.Maths;

namespace MainApp.FSM;

internal sealed class HeadToFoodSpotState : FourmizStateBase
{
    private readonly Fourmiz _fourmiz;
    private readonly FoodSpot _foodSpot;

    public HeadToFoodSpotState(Fourmiz fourmiz, FoodSpot foodSpot) : base()
    {
        _fourmiz = fourmiz;
        _foodSpot = foodSpot;
    }

    public override void Enter()
    {
        _fourmiz.LookHeadingToFoodSpot();
    }

    public override void Execute(double elapsed)
    {
        _fourmiz.HeadTo(_foodSpot.Position);

        _fourmiz.ConsumeEnergy(elapsed, 7);

        if (_fourmiz.Energy <= 0)
        {
            _fourmiz.StateMachine.ChangeState(new DiedState(_fourmiz));
        }

        // If the fourmiz is close enough to the food spot, it will start eating
        if (Vector2D.Distance(_fourmiz.Position, _foodSpot.Position) < 5f)
        {
            _fourmiz.StateMachine.ChangeState(new EatState(_fourmiz, _foodSpot));
        }
    }

    public override void Exit() { }
}
