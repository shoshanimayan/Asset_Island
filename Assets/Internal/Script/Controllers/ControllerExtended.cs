using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CMF;
using Zenject;
using System;
using UniRx;
using Core;
namespace Controllers
{
	public class ControllerExtended : AdvancedWalkerController, IView
	{


		protected override void Awake()
		{
			base.Awake();
			gravity = 0;
		}

		public void SetGravity(float Gravity)
		{
			gravity = Gravity;
		}
	}
}
