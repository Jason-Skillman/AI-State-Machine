public interface IState {
	/// <summary>
	/// Called in the update
	/// </summary>
	void Update();
	/// <summary>
	/// Called when the state has started
	/// </summary>
	void OnEnter();

	/// <summary>
	/// Called when the state has ended
	/// </summary>
	void OnExit();
}