using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace Audio
{
	public class GameAudioEffectMediator: MediatorBase<GameAudioEffectView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///
		private void OnStateChanged(StateChangeSignal signal)
		{
			_view.ClearAudio();
		}

		private void OnRecievedAudioSignal(AudioEffectSignal signal)
		{
			_view.PlayAudioClip(signal.AudioEffectName);
		}
		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///

		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<StateChangeSignal>()
				   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
			_signalBus.GetStream<AudioEffectSignal>()
				   .Subscribe(x => OnRecievedAudioSignal(x)).AddTo(_disposables);
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
