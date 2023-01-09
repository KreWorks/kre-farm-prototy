using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeedingState : GameState
{
	public WeedingState(GameManager gameManager, UIController uiController) : base(gameManager, uiController)
	{
		this.stateName = "Weeding";
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
					if (pc.currentState == pc.witherState)
					{
						pc.currentState.Weeding();
					}
				}
			}

		}

	}
}
