using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CMF;
using Zenject;
using System;
using UniRx;
using Core;
using UnityEngine.InputSystem;

namespace Inputs
{
	public class CameraInputExtendedView : CameraInput,IView
	{


		///  INSPECTOR VARIABLES      ///
		//[SerializeField] private float deadZoneThreshold = 0.2f;
		
		
		[SerializeField] private InputActionReference _CameraMovement;

		///  PRIVATE VARIABLES         ///
		private CameraInputExtendedMediator _mediator;
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



		public override float GetHorizontalCameraInput()
		{
			
			if (_mediator.MovementEnabled())
			{
				
				return _CameraMovement.action.ReadValue<Vector2>().x;
			}

			return 0;
		}

		public override float GetVerticalCameraInput()
		{
			
			if (_mediator.MovementEnabled()) {
				return _CameraMovement.action.ReadValue<Vector2>().y*-1f;

			}

			return 0;
		}

		public void Init(CameraInputExtendedMediator mediator)
		{
			_mediator = mediator;
		}



		private void Update()
		{
			//print(_input.Player.Look.ReadValue<Vector2>());
		}

		




	}
}
