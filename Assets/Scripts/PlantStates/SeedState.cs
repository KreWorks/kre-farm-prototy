using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedState : PlantState
{
	public SeedState(PlantController plantController) : base(plantController)
	{
	}

	public override void StartState()
	{
		base.StartState();
		this.plantController.ChangePlantObject(plantController.crop.seedStage);
	}

	public override void Watering()
	{
		base.Watering();
		this.plantController.TransitionState(this.plantController.growState);
	}
}
