using System;
using AI.StateMachine.States;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : Monster {

	private NavMeshAgent navMeshAgent;

	protected override void Awake() {
		base.Awake();

		navMeshAgent = GetComponent<NavMeshAgent>();
	}

	private void Start() {
		var idle = new Idle(this);
		var wander = new Wander(this);
		var moveTowards = new MoveTowards(this, navMeshAgent, target);
			
		//Setup transitions
		stateMachine.AddTransition(idle, wander, InputSpaceBar());
		stateMachine.AddTransition(wander, moveTowards, HasTarget());

		stateMachine.SetState(idle);
	}

	protected override void Update() {
		base.Update();
	}
	
	Func<bool> InputSpaceBar() => () => Input.GetKeyDown(KeyCode.Space);
	Func<bool> HasTarget() => () => target != null;

}
