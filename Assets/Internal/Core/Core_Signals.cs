using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Core
{

    public class StateChangeSignal
    {
        public State ToState;
    }

    public class LoadSceneSignal 
    {
        public State StateToLoad;
    }
    public class ActionInputSignal { }
}
