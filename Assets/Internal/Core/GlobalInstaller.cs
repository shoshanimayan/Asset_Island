using Core;
using UnityEngine;
using Zenject;
using General;
public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        //singles
        Container.Bind<StateManager>().AsSingle();
        Container.Bind<PlayerHandler>().AsSingle().NonLazy(); 
        //Signals
        Container.DeclareSignal<StateChangeSignal>();
        Container.DeclareSignal<LoadSceneSignal>();
        Container.DeclareSignal<RespawnSignal>();
        Container.DeclareSignal<ReadSignal>();
        Container.DeclareSignal<TextDisplaySignal>();
        Container.DeclareSignal<ObjectDisplaySignal>();
        Container.DeclareSignal<ActionInputSignal>();
        Container.DeclareSignal<HelperTextSignal>();
        Container.DeclareSignal<CounterIncrementSignal>();
        Container.DeclareSignal<CounterTextSignal>();
        Container.DeclareSignal<SetHintTransformSignal>();
        Container.DeclareSignal<HintSignal>();

    }
}