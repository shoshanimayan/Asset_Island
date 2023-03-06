using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace UI
{
	public class TextDisplayMediator: MediatorBase<TextDisplayView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private string _currentType=null;
		///  PRIVATE METHODS           ///
		private void FireEndedGameSignal()
		{
			_signalBus.Fire(new EndedGameSignal());
		}
		///  LISTNER METHODS           ///
		private void OnGetTextToDisplay(string[] text, string textType)
		{
			//if in play mode
			_stateManager.SetState(State.Inspector);
			_view.DisplayText(text);
			_currentType = textType;
		}
		///  PUBLIC API                ///
		public void FinishedDisplay()
		{
			if (_currentType != "Start" && _currentType != "End")
			{
				_signalBus.Fire(new CounterIncrementSignal());
			}
			if (_currentType == "End")
			{
				FireEndedGameSignal();
			}
			_currentType = null;
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
				 .Subscribe(x => OnGetTextToDisplay(x.Text,x.TextType)).AddTo(_disposables);
			_view.InitDisplay(this);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

		

	}
}
