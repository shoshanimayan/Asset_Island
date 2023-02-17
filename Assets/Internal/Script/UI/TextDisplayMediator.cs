using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
using Core;
namespace UI
{
	public class TextDisplayMediator: MediatorBase<TextDisplayView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnGetTextToDisplay(string text)
		{
			//if in play mode
			_stateManager.SetState(State.Inspector);
			_view.DisplayText(text);
		}
		///  PUBLIC API                ///
		public void FinishedDisplay()
		{
			_stateManager.ToPreviousState();
		}
		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;
		[Inject]
		private StateManager _stateManager;
		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<TextDisplaySignal>()
				 .Subscribe(x => OnGetTextToDisplay(x.Text)).AddTo(_disposables);
			_view.InitDisplay(this);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
