using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core;
using Zenject;
using System;
using UniRx;
using System.Threading.Tasks;

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
					_view.SetGravity(30);
					break;
				default:
					_view.SetGravity(0);
					break;
			}
		}

		private async void DelayedStart()
		{
			await Task.Delay(1 * 1000);
			_stateManager.SetState(State.Play);

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
		}

		public void Dispose()
		{
			_disposables.Dispose();

		}


	}

}

