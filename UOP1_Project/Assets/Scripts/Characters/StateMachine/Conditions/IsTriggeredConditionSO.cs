using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Conditions/Is Triggered Condition")]
public class IsTriggeredConditionSO : StateConditionSO<IsTriggeredCondition>
{
	public bool trigger = false;

	public void Trigger()
	{
		trigger = true;
	}
	public void Reset()
	{
		trigger = false;
	}
}

public class IsTriggeredCondition : Condition
{
	private IsTriggeredConditionSO _originSO => (IsTriggeredConditionSO)base.OriginSO; // The SO this Condition spawned from

	protected override bool Statement()
	{
		return _originSO.trigger;
	}

	public override void OnStateExit()
	{
		_originSO.Reset();
	}
}
