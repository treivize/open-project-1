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
			_actor.LookAt(_protagonist);
		}
	}
	
	public override void OnStateEnter()
	{
		_protagonist = GameObject.FindObjectOfType<Protagonist>().transform;
	}
	
	// public override void OnStateExit()
	// {
	// }
}
