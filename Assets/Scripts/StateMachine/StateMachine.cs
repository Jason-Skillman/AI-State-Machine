using System;
using System.Collections.Generic;
using UnityEngine;

namespace AI.StateMachine {
	public class StateMachine {

		public IState CurrentState { get; private set; }

		private Dictionary<Type, List<Transition>> transitions;

		private List<Transition> currentTransitions, anyTransitions;


		public StateMachine() {
			transitions = new Dictionary<Type, List<Transition>>();
			currentTransitions = new List<Transition>();
			anyTransitions = new List<Transition>();
		}

		public void Update() {
			Transition transition = GetTransition();

			if(transition != null)
				SetState(transition.To);

			CurrentState?.Update();
		}

		public void SetState(IState state) {
			if(state.Equals(CurrentState)) return;

			//Exit the existing state
			CurrentState?.OnExit();

			//Set the new state as the current state
			CurrentState = state;

			//Fetch the transitions for the new state
			transitions.TryGetValue(CurrentState.GetType(), out currentTransitions);

			//Enter the new state
			CurrentState.OnEnter();
		}

		public void AddTransition(IState from, IState to, Func<bool> predicate) {
			if(transitions.TryGetValue(from.GetType(), out var newTransitions) == false) {
				newTransitions = new List<Transition>();
				transitions[from.GetType()] = newTransitions;
			}
			newTransitions.Add(new Transition(to, predicate));
		}

		public void AddAnyTransition(IState state, Func<bool> predicate) {
			anyTransitions.Add(new Transition(state, predicate));
		}

		private Transition GetTransition() {
			if(anyTransitions != null)
				foreach(Transition transition in anyTransitions)
					if(transition.Condition())
						return transition;

			if(currentTransitions != null)
				foreach(Transition transition in currentTransitions)
					if(transition.Condition())
						return transition;

			return null;
		}

		private class Transition {

			public IState To { get; }
			public Func<bool> Condition { get; }

			public Transition(IState to, Func<bool> condition) {
				To = to;
				Condition = condition;
			}

		}

	}

}