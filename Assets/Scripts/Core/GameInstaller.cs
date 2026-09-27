using UnityEngine;
using Zenject;

public class GameInstaller: MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private PlayerConfig _playerConfig;

    public override void InstallBindings() 
    { 
        Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
        Container.Bind<IStateFactory>().To<StateFactory>().AsSingle();

        Container.BindInterfacesTo<PlayerMovement>().AsSingle();
        Container.Bind<IInputProvider>().To<PlayerInputProvider>().AsSingle();
        Container.Bind<Player>().FromComponentOn(_playerPrefab.gameObject).AsSingle();

        Container.Bind<GameInput>().AsSingle();

        Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
    }
}
