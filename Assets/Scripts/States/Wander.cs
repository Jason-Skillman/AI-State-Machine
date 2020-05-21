using UnityEngine;

namespace AI.StateMachine.States {
	public class Wander : IState {

		private AIBot aiBot;


		public Wander(AIBot aiBot) {
			this.aiBot = aiBot;
		}

		public void Update() {
			Debug.Log("State Wander update");
		}

		public void OnEnter() {
			
		}

		public void OnExit() {
			
		}
	}
}