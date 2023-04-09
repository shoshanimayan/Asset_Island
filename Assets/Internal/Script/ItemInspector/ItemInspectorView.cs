using UnityEngine;
using Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace ItemInspector
{
	public class ItemInspectorView: MonoBehaviour,IView
	{

		///  INSPECTOR VARIABLES       ///
		[SerializeField] private Transform _displayItemPosition;
		[SerializeField] private InputActionReference _inputMovement;
		[SerializeField] private float _rotSpeed=20;

		///  PRIVATE VARIABLES         ///
		private bool _showing;
		private GameObject _displayObject;
		AsyncOperationHandle<GameObject> opHandle;

		///  PRIVATE METHODS           ///
		public IEnumerator LoadAsset(string key)
		{
			opHandle = Addressables.LoadAssetAsync<GameObject>(key);
			yield return opHandle;
			if (opHandle.Status == AsyncOperationStatus.Succeeded)
			{
				GameObject obj = opHandle.Result;
				_displayObject = Instantiate(obj, _displayItemPosition.transform);


			}
			else {
				Debug.LogError(opHandle.Status);
			
			}
		}

		

		private float GetHorizontalInput()
		{

			if (_showing)
			{

				return _inputMovement.action.ReadValue<Vector2>().x;
			}

			return 0;
		}

		private  float GetVerticalInput()
		{

			if (_showing)
			{
				return _inputMovement.action.ReadValue<Vector2>().y * -1f;

			}

			return 0;
		}


		private void Update()
		{
			if (_displayObject && _showing)
			{
				_displayObject.transform.Rotate(new Vector3( 0, GetHorizontalInput(), 0) *Time.deltaTime*_rotSpeed);
			}
		}

		///  PUBLIC API                ///
		public void DisplayItem(string name)
		{
			_showing = true;
			StartCoroutine(LoadAsset(name));
		}

		public void DisposeItem()
		{
			if (_displayObject)
			{
				Destroy(_displayObject);
				_displayObject = null;
				Addressables.Release(opHandle);
			}
		}

		public void InitInspector()
		{
			_showing = false;

		}
	}
}
