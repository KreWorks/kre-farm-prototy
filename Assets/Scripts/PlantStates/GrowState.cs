using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowState : PlantState
{
	protected float growStageTime;

	public GrowState(PlantController plantController) : base(plantController)
	{
	}

	public override void StartState()
	{
		base.StartState();
		plantController.growTime = 0;
		plantController.currentGrowStage = 0;
		plantController.ChangePlantObject(plantController.crop.growStages[plantController.currentGrowStage]);

		growStageTime = plantController.crop.growTime / plantController.crop.growStages.Length;
	}

	public override void StateAction()
	{
		plantController.ConsumeWater();
		plantController.GrowPlant();

		if (plantController.growTime >= growStageTime * (plantController.currentGrowStage + 1))
		{
			plantController.currentGrowStage++;
			if (plantController.currentGrowStage < plantController.crop.growStages.Length)
			{
				plantController.ChangePlantObject(plantController.crop.growStages[plantController.currentGrowStage]);
			}
			else
			{
				plantController.TransitionState(plantController.harvestState);
			}
		}
	}
}
