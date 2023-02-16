using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using Core;
namespace General
{

	[Serializable]
	public class TextObject
	{
		public string Id;
		public string Value;
		public string Item;
	}
	
	public class TextReaderMediator: MediatorBase<TextReaderView>, IInitializable, IDisposable
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///

		///  LISTNER METHODS           ///
		private void OnReadAddressableText(int index)
		{
			string result = "";
			_view.AddresableTextAsset.LoadAssetAsync<TextAsset>().Completed += handle =>
			{
				result = handle.Result.text;
				ReadJson(result, index);
				Addressables.Release(handle);
			};
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]
		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		

		private void ReadJson(string text, int index)
		{
			Debug.Log(text);
		}

		public void Initialize()
		{
			_signalBus.GetStream<ReadSignal>()
					 .Subscribe(x => OnReadAddressableText(x.ReadIndex)).AddTo(_disposables);
		}

		public void Dispose()
		{
			
			_disposables.Dispose();

		}

	}
}
