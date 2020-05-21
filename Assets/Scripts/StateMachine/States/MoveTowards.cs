using UnityEngine;
using UnityEngine.AI;

namespace AI.StateMachine.States {
	public class MoveTowards : IState {

		private Monster monster;
		private NavMeshAgent navMeshAgent;
		private GameObject target;

		
		public MoveTowards(Monster monster, NavMeshAgent navMeshAgent, GameObject target) {
			this.monster = monster;
			this.navMeshAgent = navMeshAgent;
			this.target = target;
		}

		public void Update() {
			Debug.Log("Move Towards");
		}

		public void OnEnter() {
			navMeshAgent.SetDestination(target.transform.position);
		}

		public void OnExit() {
			
		}
	}
}