using UnityEngine;

namespace AI.StateMachine.States {
	public class Idle : IState {

		private AIBot aiBot;

		
		public Idle(AIBot aiBot) {
			this.aiBot = aiBot;
		}

		public void Update() {
			Debug.Log("State Idle update");
		}

		public void OnEnter() {
			
		}

		public void OnExit() {
			
		}
	}
}