using UnityEngine;
using Zenject;
using Core;
using Inputs;
using Controllers;
using Utility;
using General;
using UI;
using ItemInspector;
public class CoreInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {




        //Signals
   


        //binding
        Container.BindMediatorView<ControllerMediator, ControllerExtended>();
        Container.BindMediatorView<CharacterInputExtendedMediator, CharacterInputExtendedView>();
        Container.BindMediatorView<CameraInputExtendedMediator,CameraInputExtendedView>();
        Container.BindMediatorView<ActionInputMediator, ActionInputView>();
        Container.BindMediatorView<PauseMenuMediator, PauseMenuView>();
        Container.BindMediatorView<LoadingUIMediator, LoadingUIView>();
        Container.BindMediatorView<HelperUIMediator, HelperUIView>();
        Container.BindMediatorView<UiCounterMediator, UiCounterView>();
        Container.BindMediatorView<MetalDetectorMediator, MetalDetectorView>();
        Container.BindMediatorView<NavigationHintMediator, NavigationHintView>();


        Container.BindMediatorView<TextDisplayMediator, TextDisplayView>();
        Container.BindMediatorView<TextReaderMediator,TextReaderView>();
        Container.BindMediatorView< ItemInspectorMediator, ItemInspectorView>();

        Container.BindMediatorView<SceneManagerMediator, SceneManagerView>();




    }
}