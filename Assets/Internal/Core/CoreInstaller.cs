using UnityEngine;
using Zenject;
using Core;
using Inputs;
using Controllers;
using Utility;
public class CoreInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
       


        SignalBusInstaller.Install(Container);


        //Signals
        Container.DeclareSignal<StateChangeSignal>();

        //singles
        Container.Bind<StateManager>().AsSingle();
        // Container.BindInterfacesTo<ControllerExtended>().FromComponentInHierarchy().AsCached();

        //binding
        Container.BindMediatorView<ControllerMediator, ControllerExtended>();
     //   Container.BindMediatorView<CharacterInputExtendedMediator, CharacterInputExtendedView>();
        Container.BindMediatorView<CameraInputExtendedMediator,CameraInputExtendedView>();


    }
}