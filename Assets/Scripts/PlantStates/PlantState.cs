using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantState 
{
	private int wateringAmount = 2000;
	public PlantController plantController;

    public PlantState(PlantController plantController)
	{
		this.plantController = plantController;
	}

	public virtual void StartState() { }
	public virtual void LeaveState()
	{
		plantController.DestroyPlantObject();
	}

	public virtual void StateAction() { }

	public virtual void Seeding() { }
	public virtual void Watering()
	{
		plantController.AddWater(wateringAmount * Time.deltaTime);
	}
	public virtual void Harvesting() { }
	public virtual void Weeding() { }
}
