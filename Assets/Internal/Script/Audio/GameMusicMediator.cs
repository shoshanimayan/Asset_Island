using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Audio
{
	public class GameMusicMediator: MediatorBase<GameMusicView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///
		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			switch (signal.ToState)
			{
				case State.Play:
					_view.SetAudio("Play");
					break;
				case State.Pause:
					_view.PauseAudio();
					break;
				case State.Menu:
					_view.SetAudio("Menu");
					break;
				case State.Loading:
					_view.PauseAudio();
					break;
				case State.Inspector:
					_view.PauseAudio();
					break;
				
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
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
