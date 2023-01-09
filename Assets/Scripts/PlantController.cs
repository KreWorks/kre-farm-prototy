using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlantController : MonoBehaviour
{
	public PlantState currentState;

	public FieldState fieldState;
	public SeedState seedState;
	public GrowState growState;
	public HarvestState harvestState;
	public WitherState witherState;

	public CropSO crop;
	protected CropSO selectedCrop;

	public GameObject plantObject;

	public float waterLevel;
	public float growTime;
	public int currentGrowStage;

	public TMP_Text debugText;
	public Slider waterSlider;
	public Slider harvestTimer;

	GameManager gameManager;
	// Start is called before the first frame update
	void Start()
	{
		fieldState = new FieldState(this);
		seedState = new SeedState(this);
		growState = new GrowState(this);
		harvestState = new HarvestState(this);
		witherState = new WitherState(this);

		currentState = fieldState;

		crop = null;

		plantObject = null;

		waterLevel = 0;
		growTime = 0;

		gameManager = FindObjectOfType<GameManager>();
		gameManager.AddListenerChangeSelectedCropEvent(ChangeSelectedCrop);

		harvestTimer.gameObject.SetActive(false);

		debugText = GetComponentInChildren<TMP_Text>();
	}

	// Update is called once per frame
	void Update()
	{
		this.currentState.StateAction();
		ChangeText();
	}

	public void TransitionState(PlantState newState)
	{
		this.currentState.LeaveState();
		this.currentState = newState;
		this.currentState.StartState();
	}

	public void ChangeSelectedCrop(CropSO newCrop)
	{
		this.selectedCrop = newCrop;
	}

	public void SetSelectedCrop()
	{
		crop = selectedCrop;
	}

	public void ChangePlantObject(GameObject prefab)
	{
		DestroyPlantObject();

		plantObject = GameObject.Instantiate(prefab, this.transform);
		if (currentState == growState || currentState == harvestState || currentState == witherState)
		{
			plantObject.transform.localPosition = new Vector3(0, 0.7f, 0);
		}
		gameManager.plantCount++;
	}

	public void DestroyPlantObject()
	{
		if (plantObject != null)
		{
			gameManager.plantCount--;
			GameObject.Destroy(plantObject);
		}
	}

	public void AddWater(float water)
	{
		UpdateWaterLevel(waterLevel + water);
	}

	public void ConsumeWater()
	{
		UpdateWaterLevel(waterLevel - Time.deltaTime * (currentGrowStage + 1.0f));
	}

	public void ChangeHarvestTimer(float sliderValue)
	{
		harvestTimer.value = sliderValue;
	}

	public void GrowPlant()
	{
		float growMultiplier = (waterLevel / (crop.maxWater * 0.8f));
		growMultiplier = growMultiplier > 1.0f ? 1.0f : growMultiplier;

		growTime += Time.deltaTime * growMultiplier;
	}

	public void UpdateWaterLevel(float waterValue)
	{
		waterLevel = waterValue;
		waterLevel = waterLevel < 0 ? 0.0f : waterLevel;
		waterLevel = crop != null && waterLevel > crop.maxWater ? crop.maxWater : waterLevel;

		waterSlider.value = waterLevel / (crop.maxWater);
	}

	private void ChangeText()
	{
		debugText.text = "GT: " + growTime.ToString();
	}
}
