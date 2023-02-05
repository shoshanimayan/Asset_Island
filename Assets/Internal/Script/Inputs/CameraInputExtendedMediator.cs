using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core;
using Zenject;
using System;
using UniRx;

namespace Inputs
{
	public class CameraInputExtendedMediator: MediatorBase<CameraInputExtendedView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///
		private bool _movementEnabled=true;
		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			Debug.Log(signal);
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
		public  bool MovementEnabled()
		{
			return _movementEnabled;
		}


		///  IMPLEMENTATION            ///
		[Inject]
		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			view.Init(this);

			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}
	}
}
