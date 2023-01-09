using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager 
{
	public List<Message> messages;

	protected bool hasNewMessage;
	public bool HasNewMessage { get; }

	public MessageManager()
	{
		messages = new List<Message>();
		hasNewMessage = false;
	}

	public void AddMessage(MessageType type, float displayTime)
	{
		if (!HasMessage(type))
		{
			string message = GetMessageByType(type);
			messages.Add(new Message(message, type, displayTime));
			hasNewMessage = true;
		}
		else
		{
			int index = GetMessageIndex(type);
			if (!messages[index].display)
			{
				hasNewMessage = true;
				messages[index].display = true;
			}
		}
	}

    public string GetMessageByType(MessageType type)
	{
		switch (type)
		{
			case MessageType.ALERT_NO_SELECTED_CROP:
				return "You should select a crop";
			case MessageType.ALERT_NO_MONEY_TO_BUY:
				return "You have no money to buy";
			case MessageType.ALERT_NO_MONEY_TO_WATER:
				return "You have no money to water the plants";
			default:
				return "Unknown error";
		}
	}

	private bool HasMessage(MessageType type)
	{
		bool hasMsg = false;
		foreach(Message msg in messages)
		{
			if (msg.type == type)
			{
				hasMsg = true;
			}
		}

		return hasMsg;
	}

	private int GetMessageIndex(MessageType type)
	{
		int msgIndex = -1;
		for(int i =0; i < messages.Count; i++)
		{
			if (messages[i].type == type)
			{
				msgIndex = i;
			}
		}

		return msgIndex;
	}
}

