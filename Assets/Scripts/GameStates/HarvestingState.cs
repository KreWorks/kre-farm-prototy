using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingState : GameState
{
	public HarvestingState(GameManager gameManager, UIController uiController) : base(gameManager, uiController)
	{
		this.stateName = "Harvesting";
	}

	public override void ClickAction()
	{
		base.ClickAction();

		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.tag == "Field")
				{
					PlantController pc = hit.transform.gameObject.GetComponent<PlantController>();
					if (pc.currentState == pc.harvestState)
					{
						pc.currentState.Harvesting();
						gameManager.AddHarvestedItem(pc.crop, Random.Range(1,3));
					}
				}
			}
		}
	}
}
