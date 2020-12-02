using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Actions/Face Target")]
public class FaceTargetSO : StateActionSO
{
	public string targetName;

	public void SetTargetName(string targetName)
	{
		this.targetName = targetName;
	}

	protected override StateAction CreateAction() => new FaceTarget();

}

public class FaceTarget : StateAction
{
	GameObject _target;
	Transform _actor;

	public override void Awake(StateMachine stateMachine)
	{
		_actor = stateMachine.transform;
	}
		
	public override void OnUpdate()
	{
		if (_target != null)
		{
			Vector3 relativePos = _target.transform.position - _actor.position;
			relativePos.y = 0f; // Force rotation to be only on Y axis.

			Quaternion rotation = Quaternion.LookRotation(relativePos);
			_actor.rotation = rotation;
		}
	}
	
	public override void OnStateEnter()
	{
		_target = GameObject.Find(((FaceTargetSO)base.OriginSO).targetName);
	}
}
