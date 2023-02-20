using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Interactables
{
	public class InteractableManagerMediator: MediatorBase<InteractableManagerView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private int _counterMax = 0;
		private int _counterCurrent = 0;
		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnCounterIncrement(CounterIncrementSignal signal)
		{
			_counterCurrent++;
			_signalBus.Fire(new CounterTextSignal() { Text = _counterCurrent.ToString() + "/" + _counterMax.ToString() });
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			var index = 0;
			foreach (InteractableView interactable in _view.InteractableList)
			{
				interactable.SetIndex(index);
				index++;
			}
			_signalBus.GetStream<CounterIncrementSignal>()
				   .Subscribe(x => OnCounterIncrement(x)).AddTo(_disposables);
			_counterCurrent = 0;
			_counterMax = _view.InteractableList.Length;
			_signalBus.Fire(new CounterTextSignal() { Text = _counterCurrent.ToString() + "/" + _counterMax.ToString() });



		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
