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

    public class RespawnSignal { }
    public class ReadSignal {
        public int ReadIndex;
    }

    public class TextDisplaySignal {
        public string Text;
    }

    public class ObjectDisplaySignal
    {
        public string AddressableName;
    }
}
