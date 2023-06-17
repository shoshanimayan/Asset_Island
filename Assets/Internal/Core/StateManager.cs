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
			_prevState = _state;
			_state = state;
			_signalBus.Fire(new StateChangeSignal() { ToState = state });
			
		}

		public void ToPreviousState()
		{
			if (_prevState == State.Pause && _state==State.Inspector)
			{
				_prevState = State.Play;
			}
			SetState(_prevState);
		}


		///    Implementation        ///

		readonly SignalBus _signalBus;
		public StateManager(SignalBus signalBus)
		{
			_signalBus = signalBus;
			_prevState = _state;	
			_state = State.Loading;
			

		}

		
	}
}
