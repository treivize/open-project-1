using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTriggerController : MonoBehaviour
{
	[SerializeField] private VoidEventChannelSO _enterZone = default;
	[SerializeField] private VoidEventChannelSO _exitZone = default;
	[SerializeField] private LayerMask _layers = default;

	private void OnTriggerEnter(Collider other)
	{
		if ((1 << other.gameObject.layer & _layers) != 0)
		{
			_enterZone.RaiseEvent();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if ((1 << other.gameObject.layer & _layers) != 0)
		{
			_exitZone.RaiseEvent();
		}
	}
}
