using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "HasReceivedEvent", menuName = "State Machines/Conditions/Has Received Event")]
public class HasReceivedEvent : StateConditionSO<HasHitHeadCondition> {

	[SerializeField] VoidEventChannelSO _voidEvent;
	protected override Condition CreateCondition() => new HasReceivedEventCondition(_voidEvent);
}

public class HasReceivedEventCondition : Condition
{
	private VoidEventChannelSO _voidEvent;
	private bool _eventTriggered;

	public override void Awake(StateMachine stateMachine)
	{
		_eventTriggered = false;
		_voidEvent.OnEventRaised += EventReceived;
	}

	public HasReceivedEventCondition(VoidEventChannelSO voidEvent)
	{
		_voidEvent = voidEvent;
	}

	protected override bool Statement()
	{
		return _eventTriggered;
	}

	private void EventReceived()
	{
		_eventTriggered = true;
	}
}
