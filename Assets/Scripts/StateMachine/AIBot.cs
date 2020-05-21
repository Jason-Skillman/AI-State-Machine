using System;
using AI.StateMachine.States;
using UnityEngine;

namespace AI.StateMachine {
	public abstract class AIBot : MonoBehaviour {

		protected StateMachine stateMachine;


		protected virtual void Awake() {
			stateMachine = new StateMachine();
		}

		protected virtual void Update() {
			stateMachine.Update();
		}
		
	}
}