using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GameState
{
	public IdleState(GameManager gameManager, UIController uiController) : base(gameManager, uiController)
	{
		this.stateName = "Idle";
	}
}
