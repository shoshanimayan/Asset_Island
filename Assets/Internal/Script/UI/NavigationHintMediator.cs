using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
using General;

namespace UI
{
	public class NavigationHintMediator: MediatorBase<NavigationHintView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///
		private bool _canDisplay;
		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			if (signal.ToState == State.Play)
			{
				_canDisplay = true;
			}
			else
			{
				_canDisplay = false;
				_view.ForceVisiblilty(false);
			}
		}

		private void OnSetHintTransform(SetHintTransformSignal signal)
		{
			if (_canDisplay)
			{
				_view.SetTarget(signal.HintTransform);
			}
		}
		///  PUBLIC API                ///
		public Transform GetPlayerTransform()
		{
			Debug.Log(_playerHandler.GetPlayerTransform());
			return _playerHandler.GetPlayerTransform();
		}
		///  IMPLEMENTATION            ///

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private PlayerHandler _playerHandler;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<SetHintTransformSignal>()
					 .Subscribe(x => OnSetHintTransform(x)).AddTo(_disposables);
			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
			_view.ForceVisiblilty(false);
			_view.InitView(this);

		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
