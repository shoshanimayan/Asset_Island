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
        Container.BindInterfacesTo<StateManager>().AsSingle().NonLazy();
    }
}