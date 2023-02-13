using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace Interactables
{
	public class ObjectHiderView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///
		private MeshRenderer _renderer;

		///  PRIVATE METHODS           ///
		private void Awake()
		{
			_renderer = gameObject.GetComponent<MeshRenderer>();
		}
		///  PUBLIC API                ///
		public void MeshEnable(bool enabled)
		{
			if(_renderer)
			{
				_renderer.enabled = enabled;
			}

		}


	}
}
