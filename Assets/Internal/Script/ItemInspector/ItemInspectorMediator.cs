using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
namespace ItemInspector
{
	public class ItemInspectorMediator: MediatorBase<ItemInspectorView>, IInitializable, IDisposable
	{

		
		///  LISTNER METHODS           ///
		private void OnReadAddressableText(string Name)
		{
			_signalBus.Fire(new AudioEffectSignal{ AudioEffectName = "Jingle"});
			_view.DisplayItem(Name);
		}

		private void OnStateChanged(StateChangeSignal signal)
		{
			if (signal.ToState != State.Pause)
			{
				_view.DisposeItem();
			}
		}


		

	
		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<ObjectDisplaySignal>()
					 .Subscribe(x => OnReadAddressableText(x.AddressableName)).AddTo(_disposables);
			_signalBus.GetStream<StateChangeSignal>()
					   .Subscribe(x => OnStateChanged(x)).AddTo(_disposables);
		
			_view.InitInspector();
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
