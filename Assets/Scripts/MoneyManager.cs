using System;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager 
{
	public int money;
	public Action<int> onMoneyChange;

	public MoneyManager(int money)
	{
		this.money = money;
	}

	public void Buy(int price)
	{
		money -= price;

		onMoneyChange.Invoke(money);
	}

	public void Sell(int price)
	{
		money += price;
		onMoneyChange.Invoke(money);
	}

	public bool CanAfford(int price)
	{
		return price <= money;
	}

	public void AddListenerOnMoneyChange(Action<int> listener)
	{
		onMoneyChange += listener;
	}

	public void RemoveListenerOnMoneyChange(Action<int> listener)
	{
		onMoneyChange -= listener;
	}
}
