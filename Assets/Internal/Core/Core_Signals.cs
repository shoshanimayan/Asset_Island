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

    public class TextDisplaySignal
    {
        public string[] Text;
        public string TextType = null;

    }

   

    public class StartGameSignal
    {
        
    }

    public class EndedGameSignal
    {

    }

    public class EndingGameSignal
    {

    }

    public class HelperTextSignal
    {
        public string Text;
    }

    public class HintSignal
    {
    }
    public class SetHintTransformSignal
    {
        public Transform HintTransform;
    }
    public class CounterIncrementSignal
    {
        
    }

    

    public class CounterTextSignal
    {
        public string Text;
    }

  

    public class ObjectDisplaySignal
    {
        public string AddressableName;
    }
}
