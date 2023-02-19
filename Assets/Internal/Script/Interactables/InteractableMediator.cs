using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Interactables
{
	public class InteractableMediator: MediatorBase<InteractableView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///
		
		///  LISTNER METHODS           ///
		private void OnActionInput()
		{
			
			if (_view.IsTriggered() && _stateManager.GetState()==State.Play &&!_view.Interacted)
			{
				_view.Interacted = true;
				_signalBus.Fire(new ReadSignal() { ReadIndex = _view.Index });
			}
		}

		private void OnStateChanged(StateChangeSignal signal)
		{

		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]
		private StateManager _stateManager;

		[Inject]
		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<ActionInputSignal>()
					   .Subscribe(x => OnActionInput()).AddTo(_disposables);

			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
