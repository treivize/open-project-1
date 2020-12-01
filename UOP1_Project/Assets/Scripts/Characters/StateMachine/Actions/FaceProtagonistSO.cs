using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "FaceProtagonist", menuName = "State Machines/Actions/Face Protagonist")]
public class FaceProtagonistSO : StateActionSO
{
	protected override StateAction CreateAction() => new FaceProtagonist();
}

public class FaceProtagonist : StateAction
{
	Transform _protagonist;
	Transform _actor;

	public override void Awake(StateMachine stateMachine)
	{
		_actor = stateMachine.transform;
	}
		
	public override void OnUpdate()
	{
		if (_protagonist != null)
		{
			Vector3 relativePos = _protagonist.position - _actor.position;
			relativePos.y = 0f; // Force rotation to be only on Y axis.

			Quaternion rotation = Quaternion.LookRotation(relativePos);
			_actor.rotation = rotation;
		}
	}
	
	public override void OnStateEnter()
	{
		_protagonist = GameObject.FindObjectOfType<Protagonist>().transform;
	}
}
