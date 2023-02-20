using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace UI
{
	public class UiCounterMediator: MediatorBase<UiCounterView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnSetCounterText(CounterTextSignal signal)
		{
			_view.SetText(signal.Text);
		}

		private void OnStateChanged(StateChangeSignal signal)
		{
			if (signal.ToState == State.Play || signal.ToState == State.Inspector)
			{
				_view.EnableCanvas(true);
			}
			else
			{
				_view.EnableCanvas(false);
			}
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<StateChangeSignal>()
								   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
			_signalBus.GetStream<CounterTextSignal>()
					   .Subscribe(x => OnSetCounterText(x)).AddTo(_disposables);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
