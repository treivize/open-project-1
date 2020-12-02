using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class StringEvent : UnityEvent<string>
{

}

public class ZoneTriggerController : MonoBehaviour
{
	[SerializeField]private StringEvent _enterZoneEvent = default;

	[SerializeField] private StringEvent _exitZoneEvent = default;

	[SerializeField] private LayerMask _layers = default;

	private void OnTriggerEnter(Collider other)
	{
		if ((1 << other.gameObject.layer & _layers) != 0)
		{
			_enterZoneEvent.Invoke(other.gameObject.name);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if ((1 << other.gameObject.layer & _layers) != 0)
		{
			_exitZoneEvent.Invoke(other.gameObject.name);
		}
	}
}
