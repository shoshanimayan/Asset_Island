using Interactables;
using UnityEngine;
using Utility;
using Zenject;

public class InteractableInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindMediatorView<InteractableMediator, InteractableView>();
    }
}