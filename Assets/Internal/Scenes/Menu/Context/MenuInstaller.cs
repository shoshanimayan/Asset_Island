using UnityEngine;
using Zenject;
using UI;
using Utility;
using Core;

public class MenuInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
    



    

        //binding
        Container.BindMediatorView<MainMenuMediator, MainMenuView>();
       


    
    }
}