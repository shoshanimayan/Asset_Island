using UnityEngine;
using Core;
using Zenject;
using UniRx;
using System;

using UnityEngine.AddressableAssets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Collections.Generic;

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
				Read(result, index+2);
				Addressables.Release(handle);
			};
		}

		private void OnStartingGame() 
		{
			string result = "";
			_view.AddresableTextAsset.LoadAssetAsync<TextAsset>().Completed += handle =>
			{
				result = handle.Result.text;
				Read(result,0);
				Addressables.Release(handle);
			};
		}


		private void OnEndingGame()
		{
			_signalBus.Fire(new AudioEffectSignal { AudioEffectName = "Jingle" });

			string result = "";
			_view.AddresableTextAsset.LoadAssetAsync<TextAsset>().Completed += handle =>
			{
				result = handle.Result.text;
				Read(result,1);
				Addressables.Release(handle);
			};
		}
		///  PUBLIC API                ///

		///  IMPLEMENTATION            ///

		[Inject]
		private SignalBus _signalBus;

		readonly CompositeDisposable _disposables = new CompositeDisposable();

		

		private void Read(string text, int index)
		{
			
				ImportedData data = JsonConvert.DeserializeObject<ImportedData>(text);
				var textValue = data.values[index][1];
				StringReader reader = new StringReader(textValue);
				List<string> tempList = new List<string>();
				var line = string.Empty;
				do
				{
					line = reader.ReadLine();
					if (line != null && line != "")
					{
						tempList.Add(line);
					}

				} while (line != null);
				_signalBus.Fire(new TextDisplaySignal() { Text = tempList.ToArray() , TextType= data.values[index][3]}) ;

				if (data.values[index][2]!="")
				{
					var objValue = data.values[index][2];
					_signalBus.Fire(new ObjectDisplaySignal() { AddressableName = objValue });

				}
			
			
		}

		public void Initialize()
		{
			_signalBus.GetStream<ReadSignal>()
					 .Subscribe(x => OnReadAddressableText(x.ReadIndex)).AddTo(_disposables);

			_signalBus.GetStream<StartGameSignal>()
					 .Subscribe(x => OnStartingGame()).AddTo(_disposables);
			_signalBus.GetStream<EndingGameSignal>()
					 .Subscribe(x => OnEndingGame()).AddTo(_disposables);
		}

		public void Dispose()
		{
			
			_disposables.Dispose();

		}

	}
}
