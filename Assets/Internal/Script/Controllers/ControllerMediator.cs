using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core;
using Zenject;
using System;
using UniRx;

namespace Controllers
{
	public class ControllerMediator: MediatorBase<ControllerExtended>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		private void OnStateChanged(StateChangeSignal signal)
		{
			switch (signal.ToState)
			{
				case State.Play:
					view.SetGravity(30);
					break;
				default:
					view.SetGravity(0);
					break;
			}
		}

		///          INJECTIONS        ///
		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private StateManager _stateManager;


		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			
			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
			_stateManager.SetState(State.Play);

		}

		public void Dispose()
		{
			_disposables.Dispose();

		}


	}

}

