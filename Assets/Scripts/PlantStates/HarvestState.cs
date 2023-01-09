using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestState : PlantState
{
	public float life;
	public float maxLife = 20f;
	public HarvestState(PlantController plantController) : base(plantController)
	{
	}

	public override void StartState()
	{
		base.StartState();
		plantController.harvestTimer.gameObject.SetActive(true);
		plantController.ChangePlantObject(plantController.crop.harvestStage);
		life = maxLife;
	}

	public override void StateAction()
	{
		plantController.ConsumeWater();

		if (plantController.waterSlider.value < 0.8)
		{
			life -= 4.0f * Time.deltaTime;
		} 
		else
		{
			life -= Time.deltaTime;
		}

		plantController.ChangeHarvestTimer(life / maxLife);
		if (life < 0)
		{
			plantController.TransitionState(plantController.witherState);
		}
	}

	public override void Harvesting()
	{
		plantController.TransitionState(plantController.fieldState);
	}

	public override void LeaveState()
	{
		base.LeaveState();
		plantController.harvestTimer.gameObject.SetActive(false);
	}
}
