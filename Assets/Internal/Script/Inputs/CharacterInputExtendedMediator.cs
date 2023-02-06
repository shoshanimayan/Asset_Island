using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core;
using Zenject;
using System;
using UniRx;

namespace Inputs
{
	public class CharacterInputExtendedMediator : MediatorBase<CharacterInputExtendedView>, IInitializable, IDisposable
	{


		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		private bool _movementEnabled;
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


		///  IMPLEMENTATION            ///

		[Inject]
		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_view.Init(this);

			_signalBus.GetStream<StateChangeSignal>()
								   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
		}

		public void Dispose()
		{
			_disposables.Dispose();
		}
	}
}
