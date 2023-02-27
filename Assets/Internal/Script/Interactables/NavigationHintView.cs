using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace UI
{
	public class NavigationHintView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] private Transform _TrackerObj;
		[SerializeField] private Image _tracker;
		[SerializeField] [Range(0, 1)] private float _fieldOfView;
		///  PRIVATE VARIABLES         ///
		private Transform _target = null;
		private bool _visible = false;
		private Transform _camera;

		[SerializeField]
		public  bool _tracking
		{
			get { return _visible; }
			set
			{
				if (_visible == value) return;
				_visible = value;
				if (value)
				{
					_tracker.enabled = true;
				}
				else
				{
					if (_tracker.enabled)
					{
						_tracker.enabled = false;
					}
				}
			}
		}
		///  PRIVATE METHODS           ///
		private void Start()
		{
			_camera = Camera.main.transform;
			

		}
		private void Update()
		{
			if (_tracking )
			{
				Track();
			}

		}

		private void Track()
		{
			if (Vector3.Dot(_camera.forward,(_target.position-_camera.position).normalized)>= _fieldOfView)
			{
				_tracker.enabled = false;

			}
			else
			{
				var direction = _camera.InverseTransformPoint(_target.position);
				var angle = -Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

				_TrackerObj.transform.localEulerAngles = new Vector3(0.0f, 0.0f, angle);
				_tracker.enabled = true;
			}

		}
		///  PUBLIC API                ///
		public void SetTarget(Transform t)
		{
			_target = t;
			if (_target == null)
			{
				_tracking = false;
			}
			else
			{
				_tracking = true;
			}
		}

		public void ForceVisiblilty(bool visible)
		{
			_tracker.enabled = visible;
		}
	}
}
