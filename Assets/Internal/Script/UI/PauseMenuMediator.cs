using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace UI
{
	public class PauseMenuMediator: MediatorBase<PauseMenuView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			switch (signal.ToState)
			{
				case State.Pause:
					_view.EnableCanvas(true);
					break;
				default:
					_view.EnableCanvas(false);
					break;
			}
		}
		///  PUBLIC API                ///
		public void ToMenu()
		{
			_signalBus.Fire(new LoadSceneSignal { StateToLoad = State.Menu });
		}

		public void Unpause()
		{
			_stateManager.ToPreviousState();
		}
		///  IMPLEMENTATION            ///

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private StateManager _stateManager;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
			_view.Init(this);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
