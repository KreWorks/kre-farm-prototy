using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		/*if (msg.display)
		{
			msg.displayTime += Time.deltaTime;
			if (msg.displayTime > msg.showTime)
			{

			}
		}
		else
		{
			GameObject msgObject = Instantiate(messagePrefab);
			msgObject.GetComponent<Image>().color = msg.type == MessageType.ALERT ? alertColor : msg.type == MessageType.SUCCESS ? successColor : infoColor;
			msgObject.GetComponentInChildren<TMP_Text>().text = msg.message;
			msg.display = true;
		}*/
	}
}
