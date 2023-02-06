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
		private bool _movementEnabled;

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{

			switch (signal.ToState)
			{
				case State.Play:
					_movementEnabled = true;
					break;
				default:
					_movementEnabled = false;
					break;
			}
		}
		///  PUBLIC API                ///
		public bool MovementEnabled()
		{
			return _movementEnabled;
		}

		public void DispatchActionSignal()
		{
			if (_movementEnabled)
			{
				_signalBus.Fire(new ActionInputSignal { });
			}

		}
		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
			view.Init(this);

		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
