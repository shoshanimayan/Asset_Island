using UnityEngine;
using Zenject;
using Core;

public class CoreInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);


        //Signals
        Container.DeclareSignal<StateChangeSignal>();

        //singles
        Container.Bind<StateManager>().AsSingle().NonLazy();
    }
}