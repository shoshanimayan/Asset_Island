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
			_view.DisplayText(text);
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<TextDisplaySignal>()
				 .Subscribe(x => OnGetTextToDisplay(x.Text)).AddTo(_disposables);
			_view.InitDisplay();
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
