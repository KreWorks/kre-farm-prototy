using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitherState : PlantState
{
	public WitherState(PlantController plantController) : base(plantController)
	{
	}

	public override void StartState()
	{
		base.StartState();
		plantController.ChangePlantObject(plantController.crop.witherStage);
		plantController.harvestTimer.gameObject.SetActive(false);
	}

	public override void Weeding()
	{
		base.Weeding();
		plantController.TransitionState(plantController.fieldState);
	}
}
