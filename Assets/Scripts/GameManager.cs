using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public UIController uiController;

	public GameState currentState;

	public IdleState idleState;
	public ShoppingState shoppingState;
	public SeedingState seedingState;
	public WateringState wateringState;
	public HarvestingState harvestingState;
	public WeedingState weedingState;

	public List<CropSO> crops;
	public List<Item> inventory;

	public CropSO selectedCrop;

	public Action<CropSO> changeSelectedCropEvent;

	public MoneyManager moneyManager;

	public int plantCount;

	// Start is called before the first frame update
	void Start()
    {
		this.idleState = new IdleState(this, uiController);
		this.shoppingState = new ShoppingState(this, uiController);
		this.seedingState = new SeedingState(this, uiController);
		this.wateringState = new WateringState(this, uiController);
		this.harvestingState = new HarvestingState(this, uiController);
		this.weedingState = new WeedingState(this, uiController);

		this.currentState = idleState;

		this.inventory = new List<Item>();
		currentState.StartState();

		uiController.SetCropList(crops);

		moneyManager = new MoneyManager(100);
		uiController.ChangeMoney(moneyManager.money);
		moneyManager.AddListenerOnMoneyChange(uiController.ChangeMoney);
		plantCount = 0;
	}

    // Update is called once per frame
    void Update()
    {
		this.currentState.StateAction();
		this.currentState.ClickAction();
	}

	public void TransitionState(GameState newState)
	{
		this.currentState.LeaveState();
		this.currentState = newState;
		this.currentState.StartState();
	}

	public void ChangeState(string stateString)
	{
		switch(stateString)
		{
			case "buy":
				this.TransitionState(shoppingState);
				break;
			case "seed":
				this.TransitionState(seedingState);
				break;
			case "water":
				this.TransitionState(wateringState);
				break;
			case "harvest":
				this.TransitionState(harvestingState);
				break;
			case "weed":
				this.TransitionState(weedingState);
				break;
			default:
				this.TransitionState(idleState);
				break;
		}
	}

	public void ChangeSelectedCrop(string cropName)
	{
		foreach (CropSO crop in crops)
		{
			if (crop.name == cropName)
			{
				this.selectedCrop = crop;
				changeSelectedCropEvent.Invoke(crop);
				return;
			}
		}
	}

	public void AddHarvestedItem(CropSO crop, int amount)
	{
		Item harvesteditem = new Item(crop, StageType.FRUIT, amount);
		int itemCount = 0;
		bool isInInventory = false;
		foreach(Item item in inventory)
		{
			if (item.crop == crop && item.type == StageType.FRUIT)
			{
				item.amount += amount;
				isInInventory = true;
			}
			itemCount += item.amount;
		}
		if (!isInInventory)
		{
			inventory.Add(harvesteditem);
			itemCount += amount;
		}
		moneyManager.Sell(crop.fruitPrice * amount);
		uiController.ChangeMoney(moneyManager.money);
		
	}

	public void AddListenerChangeSelectedCropEvent(Action<CropSO> listener)
	{
		changeSelectedCropEvent += listener;
	}

	public void RemoveListenerChangeSelectedCropEvent(Action<CropSO> listener)
	{
		changeSelectedCropEvent -= listener;
	}
}
