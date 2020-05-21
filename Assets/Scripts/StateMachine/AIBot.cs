using System;
using AI.StateMachine.States;
using UnityEngine;

namespace AI.StateMachine {
	public class AIBot : MonoBehaviour {

		private StateMachine stateMachine;


		private void Awake() {
			stateMachine = new StateMachine();
		}

		private void Start() {
			var idle = new Idle(this);
			var wander = new Wander(this);
			
			//Setup transitions
			stateMachine.AddTransition(idle, wander, InputSpaceBar());


			Func<bool> InputSpaceBar() => () => Input.GetKeyDown(KeyCode.Space);
			
			
			
			stateMachine.SetState(idle);
		}

		private void Update() {
			stateMachine.Update();
		}

	}
}