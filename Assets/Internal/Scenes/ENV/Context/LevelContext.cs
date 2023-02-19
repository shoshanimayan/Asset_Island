using Zenject;
using Utility;
using Interactables;
public class LevelContext : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindMediatorView<InteractableMediator,InteractableView>();
        Container.BindMediatorView<InteractableManagerMediator, InteractableManagerView>();
        Container.BindMediatorView<ObjectHiderMediator, ObjectHiderView>();

    }
}