using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldState : PlantState
{
	public FieldState(PlantController plantController) : base(plantController)
	{
	}

	public override void StartState()
	{
		base.StartState();
		plantController.UpdateWaterLevel(0);
	}

	public override void Watering()	{}

	public override void Seeding()
	{
		this.plantController.SetSelectedCrop();
		this.plantController.ChangePlantObject(this.plantController.crop.seedStage);
		this.plantController.TransitionState(this.plantController.seedState);
	}

}
