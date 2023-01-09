using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "ScriptableObjects/Crop", order = 1)]
public class CropSO : ScriptableObject
{
	public string plantName;

	public int seedPrice;
	public int fruitPrice;

	public float growTime;
	public float maxWater;

	public GameObject seedStage;
	public GameObject[] growStages;
	public GameObject harvestStage;
	public GameObject witherStage;
	public GameObject fruit;

	public int GetStagesCount()
	{
		return growStages.Length + 2;
	}
}
