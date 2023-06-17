using UnityEngine;

using CMF;

using Core;
using UnityEngine.InputSystem;

namespace Controllers
{
	public class ControllerExtended : AdvancedWalkerController, IView
	{

		[SerializeField] private InputActionReference _sprintInput;

		

		protected override void Awake()
		{

			_sprintInput.action.started += ctx => movementSpeed *= 2f;
			_sprintInput.action.canceled += ctx => movementSpeed /= 2f;

			base.Awake();
			gravity = 0;
		}

		public void SetGravity(float Gravity)
		{
			gravity = Gravity;
		}


	}
}
