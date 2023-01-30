using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Zenject;
using System;
using UniRx;

namespace Core
{
	public enum State {Loading,Menu,Pause,Play }
	public class StateManager : IInitializable, IDisposable
	{



		///  INSPECTOR VARIABLES      ///

		///  PRIVATE VARIABLES         ///
		private State _state;


		///  PRIVATE METHODS          ///

		///  LISTNER METHODS          ///

		private void OnStateChanged(State state)
		{
			_state = state;
			Debug.Log(_state);
		}


		///  PUBLIC API               ///
		readonly SignalBus _signalBus;
		readonly CompositeDisposable _disposables = new CompositeDisposable();
		

		public State GetState()
		{
			return _state;
		}


		///    Implementation        ///


		public StateManager(SignalBus signalBus)
		{
			_signalBus = signalBus;

			_state = State.Loading;

		}

		public void Dispose()
		{
			_disposables.Dispose();
		}


		public void Initialize()
		{
			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x.ToState)).AddTo(_disposables);

			_signalBus.Fire(new StateChangeSignal() { ToState = State.Play });

		}
	}
}
