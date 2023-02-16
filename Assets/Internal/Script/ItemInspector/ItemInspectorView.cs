using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

namespace ItemInspector
{
	public class ItemInspectorView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] private Transform DisplayItemPosition;
		[SerializeField] private InputActionReference _ActionInput;

		///  PRIVATE VARIABLES         ///
		private bool _showing;
		///  PRIVATE METHODS           ///
		private void LoadAsset(AssetReference asset)
		{ 
		
		}

		private void Proceed()
		{ 
		
		}
		///  PUBLIC API                ///
		public void DisplayItem(string Name)
		{
			_showing = true;
		}

		public void InitInspector()
		{
			_showing = false;
			_ActionInput.action.performed += ctx => Proceed();

		}
	}
}
