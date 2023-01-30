using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace Core
{
	public enum State {Loading,Menu,Pause,Play }
	public class StateManager
	{



		///  INSPECTOR VARIABLES      ///

		///  PRIVATE VARIABLES         ///
		private State _state;
		///  PRIVATE METHODS          ///
		
		///  PUBLIC API               ///

		public StateManager()
		{
			_state = State.Loading;
			Debug.Log(_state);

		}

		public State GetState()
		{
			return _state;
		}
	}
}
