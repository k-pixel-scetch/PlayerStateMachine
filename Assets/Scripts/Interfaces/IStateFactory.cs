public interface IStateFactory
{
    IState CreateState(PlayerStateType type);
}