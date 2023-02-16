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

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnReadAddressableText(string Name)
		{
			_view.DisplayItem(Name);
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]

		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		public void Initialize()
		{
			_signalBus.GetStream<ObjectDisplaySignal>()
					 .Subscribe(x => OnReadAddressableText(x.AddressableName)).AddTo(_disposables);

			_view.InitInspector();
		}

		public void Dispose()
		{

			_disposables.Dispose();

		}

	}
}
