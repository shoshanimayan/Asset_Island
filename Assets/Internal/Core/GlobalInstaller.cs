using Core;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller<GlobalInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        //singles
        Container.Bind<StateManager>().AsSingle().NonLazy();
        //Signals
        Container.DeclareSignal<StateChangeSignal>();
        Container.DeclareSignal<LoadSceneSignal>();
    }
}