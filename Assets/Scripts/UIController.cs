using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
	public TMP_Text stateName;
	public TMP_Text moneyText;

	public Button cancelButton;

	public GameObject seedSelector;
	public GameObject cropButtonPrefab;

	public MessageManager messageManager;
	public GameObject messagePrefab;
	public GameObject messageBox;
	/*public List<Message> messages;
	
	public Color alertColor;
	public Color infoColor;
	public Color successColor;*/

	void Start()
	{
		this.seedSelector.SetActive(false);
		messageManager = new MessageManager();
	}

	private void Update()
	{
		if (messageManager.messages.Count > 0)
		{
			foreach(Message msg in messageManager.messages)
			{
				if (msg.display && msg.messagePanel == null)
				{
					GameObject msgObject = Instantiate(messagePrefab, messageBox.transform);
					msgObject.GetComponent<Image>().color = new Color(1, 0, 0,0.3f);
					msgObject.GetComponentInChildren<TMP_Text>().text = msg.message;
					msg.messagePanel = msgObject;
				} else if (msg.display && msg.messagePanel != null && !msg.messagePanel.activeSelf)
				{
					msg.displayTime = 0.0f;
					msg.messagePanel.SetActive(true);
				}

				if (msg.display)
				{
					msg.displayTime += Time.deltaTime;
					if (msg.displayTime > msg.showTime)
					{
						msg.messagePanel.SetActive(false);
						msg.display = false;
					}
				}
			}
		}
	}

	public void ChangeStateString(string stateName)
	{
		this.stateName.text = stateName;
		if (stateName != "Idle")
		{
			cancelButton.gameObject.SetActive(true);
		}
		else
		{
			cancelButton.gameObject.SetActive(false);
		}
	}

	public void ChangeMoney(int count)
	{
		moneyText.text = count.ToString();
	}

	public void ToggleSeedSelector()
	{
		this.seedSelector.SetActive(!this.seedSelector.activeSelf);
	}

	public void SetCropList(List<CropSO> crops)
	{
		GameManager gameManager = FindObjectOfType<GameManager>();
		foreach(CropSO crop in crops)
		{
			GameObject cropButton = GameObject.Instantiate(cropButtonPrefab);
			RectTransform rt = cropButton.GetComponent<RectTransform>();
			rt.SetParent(seedSelector.transform);
			rt.localScale = new Vector3(1, 1, 1);
			rt.localPosition = new Vector3(rt.position.x, rt.position.y, 0);
			cropButton.name = crop.name;
			cropButton.GetComponentInChildren<TMP_Text>().text = crop.name;
			cropButton.GetComponent<Button>().onClick.AddListener(delegate { gameManager.ChangeSelectedCrop(crop.name); });
		}
	}

	public void AddMessage(MessageType type, float time)
	{
		messageManager.AddMessage(type, time);
	}
}
