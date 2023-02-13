using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Inputs
{
	public class ActionInputMediator: MediatorBase<ActionInputView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private bool _enabled;

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{

			switch (signal.ToState)
			{
				case State.Play:
					_enabled = true;
					break;
				default:
					_enabled = false;
					break;
			}
		}
		///  PUBLIC API                ///
		public bool MovementEnabled()
		{
			return _enabled;
		}

		public void DispatchPause()
		{
			if (_enabled)
			{
				_stateManager.SetState(State.Pause);
				return;
			}
			else if (_stateManager.GetState() == State.Pause)
			{
				Debug.Log(true);

				_stateManager.ToPreviousState();
			}
			
		}

		public void DispatchActionSignal()
		{
			if (_enabled)
			{
				_signalBus.Fire(new ActionInputSignal { });
			}

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
