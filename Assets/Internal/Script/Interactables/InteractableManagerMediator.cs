using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
using General;
namespace Interactables
{
	public class InteractableManagerMediator: MediatorBase<InteractableManagerView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private int _counterMax = 0;
		private int _counterCurrent = 0;
		///  PRIVATE METHODS           ///
		private Transform GetNearestInteractable()
		{
			float distance=float.MaxValue;
			Transform result = null;
			foreach (var i in _view.InteractableList)
			{
				var tempDistance = Vector3.Distance(_playerHandler.GetPlayerWorldPosition(), i.transform.position);
				if (tempDistance < distance)
				{
					result = i.transform;
					distance = tempDistance;
				}
			}
			

			return result;
		
		}

		///  LISTNER METHODS           ///
		private void OnCounterIncrement(CounterIncrementSignal signal)
		{
	
			_counterCurrent++;
			_signalBus.Fire(new CounterTextSignal() { Text = _counterCurrent.ToString() + "/" + _counterMax.ToString() });
		}


		private void OnRecievedHintSignal(HintSignal signal)
		{
			var NearestInteractable = GetNearestInteractable();
			_signalBus.Fire(new SetHintTransformSignal() { HintTransform = NearestInteractable });

		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]
		private SignalBus _signalBus;

		[Inject]
		private PlayerHandler _playerHandler;

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
			_signalBus.GetStream<HintSignal>()
				   .Subscribe(x => OnRecievedHintSignal(x)).AddTo(_disposables);
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
