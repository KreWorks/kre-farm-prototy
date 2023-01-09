using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingState : GameState
{
	public ShoppingState(GameManager gameManager, UIController uiController) : base(gameManager, uiController)
	{
		this.stateName = "Shopping";
	}
}
