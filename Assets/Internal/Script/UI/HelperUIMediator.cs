using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace UI
{
	public class HelperUIMediator: MediatorBase<HelperUIView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///
		private bool _listening;
		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			_view.SetHelperText("");
			if (signal.ToState == State.Play)
			{
				_listening = true;
			}
			else 
			{
				_listening = false;
			}
		}

		private void OnHelperTextRecieved(HelperTextSignal signal)
		{
			if (_listening)
			{
				_view.SetHelperText(signal.Text);
			}
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_view.SetHelperText("");
			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
			_signalBus.GetStream<HelperTextSignal>()
					   .Subscribe(x => OnHelperTextRecieved(x)).AddTo(_disposables);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
