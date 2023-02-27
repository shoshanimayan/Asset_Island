using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
namespace General
{
	public class MetalDetectorView: MonoBehaviour,IView
	{
		private MeshRenderer _renderer;
		private MeshRenderer[] _childrenders;
		///  INSPECTOR VARIABLES       ///

		///  PRIVATE VARIABLES         ///

		///  PRIVATE METHODS           ///
		private void Awake()
		{
			_renderer = GetComponent<MeshRenderer>();
			_childrenders = GetComponentsInChildren<MeshRenderer>();
		}
		///  PUBLIC API                ///
		public void SetRenderer(bool render)
		{
			_renderer.enabled = render;
			foreach (var c in _childrenders)
			{
				c.enabled = render;
			}
		}
	}
}
