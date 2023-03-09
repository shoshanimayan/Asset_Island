using UnityEngine;
using Core;

using TMPro;
using UnityEngine.InputSystem;
using System.Threading.Tasks;
using System.Threading;
using Utility.Enums;
namespace UI
{
	public class TextDisplayView : MonoBehaviour, IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] private Canvas _pauseCanvas;
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private TextMeshProUGUI _helperText;
		//[SerializeField] private InputActionReference _ActionInput;

		///  PRIVATE VARIABLES         ///
		private bool _displaying;
		private bool _writing;
		private CancellationTokenSource _cToken;
		private TextDisplayMediator _mediator;
		private string[] _currentMessages;
		private int _index = 0;
		///  PRIVATE METHODS           ///


		private async Task TypeText(string text, CancellationToken t = default)
		{
			_writing = true;
			_text.text = text;
			_text.maxVisibleCharacters = 0;
			var TotalVisibleCharacters = text.Length;
			int counter = 0;
			while (counter < TotalVisibleCharacters + 1)
			{
				if (t.IsCancellationRequested)
				{
					_text.maxVisibleCharacters = TotalVisibleCharacters;
					_writing = false;

					return;
				}
				int visibleCount = counter % (TotalVisibleCharacters + 1);

				_text.maxVisibleCharacters = visibleCount;


				counter++;
				await Task.Delay(5 * 10);
			}
			_writing = false;
		}
		///  PUBLIC API                ///
		public async void DisplayText(string[] text)
		{
			_currentMessages = text;
			var key = "E or click";
			if (Gamepad.current != null)
			{
				if (Gamepad.current.added)
				{
					key = "X";
				}
			}
			_helperText.text = string.Format("press {0} to Continue", key);

			_text.text = "";
			_displaying = true;
			_pauseCanvas.enabled = true;
			if (_cToken == null)
			{
				_cToken = new CancellationTokenSource();

			}
			_index = 0;
			await TypeText(_currentMessages[_index], _cToken.Token);
		}

		public void InitDisplay(TextDisplayMediator mediator)
		{
			_mediator = mediator;
			//_ActionInput.action.performed += ctx =>ProceedText(ctx);
			_pauseCanvas.enabled = false;



		}

		public async void ProceedText()
		{

			if (_displaying && _writing && _cToken != null)
			{
				_cToken.Cancel();
				_cToken.Dispose();
				_cToken = new CancellationTokenSource();
			}
			else if (_displaying)
			{
				_index++;
				if (_index >= _currentMessages.Length)
				{
					_cToken.Cancel();
					_cToken.Dispose();
					_cToken = new CancellationTokenSource();
					_displaying = false;
					_pauseCanvas.enabled = false;
					_mediator.FinishedDisplay();
				}
				else
				{
					_text.text = "";
					_displaying = true;
					_pauseCanvas.enabled = true;
					if (_cToken == null)
					{
						_cToken = new CancellationTokenSource();

					}
					await TypeText(_currentMessages[_index], _cToken.Token);
				}

			}
		}
	}
}
