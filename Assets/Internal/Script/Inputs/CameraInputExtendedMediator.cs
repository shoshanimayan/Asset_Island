using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Core;
using Zenject;
using System;
using UniRx;
using UnityEngine.InputSystem;

namespace Inputs
{
	public class CameraInputExtendedMediator: MediatorBase<CameraInputExtendedView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private bool _movementEnabled;

		///  PRIVATE METHODS           ///

		private void CursorMode(CursorLockMode mode)
		{
			Cursor.lockState = mode;
		}

		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			
			switch (signal.ToState)
			{
				case State.Play:
					_movementEnabled = true;
					CursorMode(CursorLockMode.Locked);
					break;
				case State.Inspector:
					CursorMode(CursorLockMode.Locked);
					_movementEnabled = false;
					break;
				
				default:
					CursorMode(CursorLockMode.Confined);
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
