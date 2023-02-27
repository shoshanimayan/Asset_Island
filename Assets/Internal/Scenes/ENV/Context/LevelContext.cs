using Zenject;
using Utility;
using Interactables;
using Core;
public class LevelContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindMediatorView<InteractableManagerMediator, InteractableManagerView>();
    }
}