using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderZoneController : MonoBehaviour
{
	[SerializeField] private VoidEventChannelSO _enterZone = default;

	[SerializeField] private VoidEventChannelSO _exitZone = default;

	private void OnTriggerEnter(Collider other)
	{
		if (other.GetComponent<Protagonist>() != null)
		{
			_enterZone.RaiseEvent();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.GetComponent<Protagonist>() != null)
		{
			_exitZone.RaiseEvent();
		}
	}
}
