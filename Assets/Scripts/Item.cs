using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item 
{
	public CropSO crop;
	public StageType type;
	public int amount;

	public Item(CropSO crop, StageType type, int amount)
	{
		this.crop = crop;
		this.type = type;
		this.amount = amount;
	}
	
	public int GetPrice()
	{
		if(type == StageType.SEED)
		{
			return crop.seedPrice;
		}
		else
		{
			return crop.fruitPrice;
		}
	}
}

public enum StageType
{
	SEED,
	FRUIT
}
