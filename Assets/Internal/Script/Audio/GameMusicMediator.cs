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
		private float _volume;
		///  LISTNER METHODS           ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			switch (signal.ToState)
			{
				case State.Play:
					_view.SetAudio("Play");
					_view.setVolume(_volume );

					break;
				case State.Pause:
					_view.setVolume(_volume / 2);

					break;
				case State.Menu:
					_view.SetAudio("Menu");
					_view.setVolume(_volume / 2);

					break;
				case State.Loading:
					_view.setVolume(_volume / 2);
					break;
				case State.Inspector:
					_view.setVolume(_volume / 2);
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
			_volume = _view.GetVolume();
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
