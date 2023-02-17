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
        Container.DeclareSignal<ReadSignal>();
        Container.DeclareSignal<TextDisplaySignal>();
        Container.DeclareSignal<ObjectDisplaySignal>();
        Container.DeclareSignal<ActionInputSignal>();


        //binding
        Container.BindMediatorView<ControllerMediator, ControllerExtended>();
        Container.BindMediatorView<CharacterInputExtendedMediator, CharacterInputExtendedView>();
        Container.BindMediatorView<CameraInputExtendedMediator,CameraInputExtendedView>();
        Container.BindMediatorView<ActionInputMediator, ActionInputView>();
        Container.BindMediatorView<SceneManagerMediator,SceneManagerView>();
        Container.BindMediatorView<PauseMenuMediator, PauseMenuView>();
        Container.BindMediatorView<LoadingUIMediator, LoadingUIView>();
        Container.BindMediatorView<TextDisplayMediator, TextDisplayView>();
        Container.BindMediatorView<TextReaderMediator,TextReaderView>();
        Container.BindMediatorView< ItemInspectorMediator, ItemInspectorView>();





    }
}