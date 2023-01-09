using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringState : GameState
{
	public int waterPrice = 5;

	public WateringState(GameManager gameManager, UIController uiController) : base(gameManager, uiController)
	{
		this.stateName = "Watering";
	}

	public override void ClickAction()
	{
		base.ClickAction();

		
		if (Input.GetMouseButtonDown(0))
		{
			if (gameManager.moneyManager.CanAfford(waterPrice))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.transform.tag == "Field")
					{
						PlantController pc = hit.transform.gameObject.GetComponent<PlantController>();
						pc.currentState.Watering();
						gameManager.moneyManager.Buy(waterPrice);
					}
				}
			}
			else
			{
				uiController.AddMessage(MessageType.ALERT_NO_MONEY_TO_WATER, 3.0f);
			}
		}
		
	}
}
