using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedingState : GameState
{
	public SeedingState(GameManager gameManager, UIController uiController) : base(gameManager, uiController)
	{
		this.stateName = "Seeding";
	}

	public override void StartState()
	{
		base.StartState();
		uiController.ToggleSeedSelector();
	}

	public override void LeaveState()
	{
		base.LeaveState();
		uiController.ToggleSeedSelector();
	}

	public override void ClickAction()
	{
		base.ClickAction();
		
		if (Input.GetMouseButtonDown(0))
		{
			if (gameManager.selectedCrop != null && gameManager.moneyManager.CanAfford(gameManager.selectedCrop.seedPrice))
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit))
				{
					if (hit.transform.tag == "Field")
					{
						PlantController pc = hit.transform.gameObject.GetComponent<PlantController>();
						pc.currentState.Seeding();
						gameManager.moneyManager.Buy(pc.crop.seedPrice);
					}
				}
			}
			else
			{
				if (gameManager.selectedCrop == null)
				{
					uiController.AddMessage(MessageType.ALERT_NO_SELECTED_CROP, 3.0f);
				}
				if (gameManager.selectedCrop != null && !gameManager.moneyManager.CanAfford(gameManager.selectedCrop.seedPrice))
				{
					uiController.AddMessage(MessageType.ALERT_NO_MONEY_TO_BUY, 3.0f);
				}
			}
		}
		
	}
}
