using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CMF;
using Core;
using UnityEngine.InputSystem;

namespace Inputs
{
	public class CharacterInputExtendedView : CharacterInput,IView
	{


		///  INSPECTOR VARIABLES      ///
		[SerializeField] private InputActionReference _playerMovement;

		[SerializeField] private InputActionReference _jumpInput;

		///  PRIVATE VARIABLES         ///


		private CharacterInputExtendedMediator _mediator;

		private DefaultInputActions _input;

		///  PRIVATE METHODS          ///
		private void OnEnable()
		{
			_input.Enable();
		}

		private void OnDisable()
		{
			_input.Disable();
		}

		private void Awake()
		{
			_input = new DefaultInputActions();
		}
		///  PUBLIC API               ///



		public override float GetHorizontalMovementInput()
		{
			if (_mediator.MovementEnabled())
			{
				return _playerMovement.action.ReadValue<Vector2>().x;

			}

			return 0;
		}

		public override float GetVerticalMovementInput()
		{
			if (_mediator.MovementEnabled())
			{
				return _playerMovement.action.ReadValue<Vector2>().y;

			}

			return 0;
		}

		private void Update()
		{
		}

		public override bool IsJumpKeyPressed()
		{
			if (_mediator.MovementEnabled())
			{
				return _jumpInput.action.ReadValue<float>() != 0;
			}
			return false;
		}

		public void Init(CharacterInputExtendedMediator mediator)
		{
			_mediator = mediator;
		}


	}
}
