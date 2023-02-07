using UnityEngine;
using Zenject;
using Core;
using Inputs;
using Controllers;
using Utility;
using General;
public class CoreInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
       


       

       

        //binding
        Container.BindMediatorView<ControllerMediator, ControllerExtended>();
        Container.BindMediatorView<CharacterInputExtendedMediator, CharacterInputExtendedView>();
        Container.BindMediatorView<CameraInputExtendedMediator,CameraInputExtendedView>();
        Container.BindMediatorView<ActionInputMediator, ActionInputView>();
        Container.BindMediatorView<SceneManagerMediator,SceneManagerView>();


    }
}