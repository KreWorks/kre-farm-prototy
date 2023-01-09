using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message
{
	public string message;
	public MessageType type;
	public float showTime;
	public bool display;
	public float displayTime;
	public GameObject messagePanel;

	public Message(string message, MessageType type, float time)
	{
		this.message = message;
		this.type = type;
		this.showTime = time;
		this.display = true;
		this.displayTime = 0.0f;
		this.messagePanel = null;
	}
}

