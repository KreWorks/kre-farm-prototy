using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState 
{
	public GameManager gameManager;
	public UIController uiController;

	protected string stateName;

	public GameState(GameManager gameManager, UIController uiController)
	{
		this.gameManager = gameManager;
		this.uiController = uiController;

		this.stateName = "Base";
	}

	public virtual void StartState()
	{
		this.uiController.ChangeStateString(this.stateName);
	}
	public virtual void LeaveState() { }

	public virtual void StateAction() { }

	public virtual void ClickAction() { }
}
