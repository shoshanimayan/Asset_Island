using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;

using UnityEngine.AddressableAssets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace General
{
	[Serializable]
	public class ImportedData
	{
		public string range;
		public string majorDimension;
		public string[][] values;
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
			ImportedData data = JsonConvert.DeserializeObject<ImportedData>(text);
			var textValue = data.values[index][1];
			_signalBus.Fire(new TextDisplaySignal() { Text=textValue});

			if (2 < data.values[index].Length)
			{ 
				var objValue= data.values[index][2];
				_signalBus.Fire(new ObjectDisplaySignal() { AddressableName=objValue });

			}
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
