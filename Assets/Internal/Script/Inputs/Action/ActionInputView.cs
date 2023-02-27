using UnityEngine;
using Core;
using UnityEngine.InputSystem;

namespace Inputs
{
	public class ActionInputView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] private InputActionReference _ActionInteractInput;
		[SerializeField] private InputActionReference _PauseInput;
		[SerializeField] private InputActionReference _hintInput;


		///  PRIVATE VARIABLES         ///
		private ActionInputMediator _mediator;
		///  PRIVATE METHODS           ///

		///  PUBLIC API                ///
		public void Init(ActionInputMediator mediator)
		{
			_mediator = mediator;

			_ActionInteractInput.action.performed += ctx => _mediator.DispatchActionSignal();
			_hintInput.action.performed += ctx => _mediator.DispatchHintSignal();

			_PauseInput.action.performed += ctx => _mediator.DispatchPause();
		}
	}
}
