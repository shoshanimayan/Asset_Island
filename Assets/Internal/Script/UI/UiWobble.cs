using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiWobble : MonoBehaviour
{
    ///  INSPECTOR VARIABLES      ///

    [SerializeField] private bool _enabled;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float maxRotation = 10f;
    ///  PRIVATE METHODS          ///
    private void Update()
    {
        if (_enabled)
        {
            var targetAngle = Quaternion.Euler(Vector3.forward * maxRotation * (Mathf.Sin(Time.time * speed)));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetAngle, Time.deltaTime);
        }
    }
    ///  PUBLIC API               ///

    public void EnableSquish(bool enabled)
    {
        _enabled = enabled;
        if (!enabled)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }
}
