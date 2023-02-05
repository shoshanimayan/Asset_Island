using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zenject;
using System;
using UniRx;

namespace Core
{
	public enum State {Loading,Menu,Pause,Play, Inspector}
	public class StateManager : IstateManager
	{



		///  INSPECTOR VARIABLES      ///

		///  PRIVATE VARIABLES         ///
		private State _state;
		private State _prevState;

		///  PRIVATE METHODS          ///

		///  LISTNER METHODS          ///

		


		///  PUBLIC API               ///
		
		

		public State GetState()
		{
			return _state;
		}

		public void SetState(State state)
		{
			_signalBus.Fire(new StateChangeSignal() { ToState = state });

		}


		///    Implementation        ///

		readonly SignalBus _signalBus;
		public StateManager(SignalBus signalBus)
		{
			_signalBus = signalBus;
			
			_state = State.Loading;
			

		}

		
	}
}
