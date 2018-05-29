using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;

using System;

public class mqttTest : MonoBehaviour {
	private MqttClient client;


	private float nextTime = 0;
	public GameObject leftHand;
	public GameObject rightHand;
	private string[] values;
	private string value; 

	public int switch1;
	public int switch2;
	public int switch3;
	public int switch4;
	public int slider1;
	public int slider2;
	public int slider3;
	public int pot1;
	public int pot2;
	public int pot3;

	public float humidity;
	public float pressure;
	public float temperature;

	public int randPreset1 = 1;
	public int randPreset2 = 2;

	// Use this for initialization
	void Start () {
		// create client instance 
		client = new MqttClient( "broker.shiftr.io" ); 
		
		// register to message received 
		client.MqttMsgPublishReceived += client_MqttMsgPublishReceived; 

//		string clientId = Guid.NewGuid().ToString(); 
		string clientId = "Unity";
		client.Connect(clientId, "f6e30b4f", "ad071b8006445200" ); 
		
		// subscribe to the topic "/home/temperature" with QoS 2 
		client.Subscribe(new string[] { "active/switch1" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/switch2" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/switch3" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/switch4" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/potentiometer1" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/potentiometer2" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/potentiometer3" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/slider1" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/slider2" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "active/slider3" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });


		client.Subscribe(new string[] { "passive/tmp" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "passive/hum" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 
		client.Subscribe(new string[] { "passive/prs" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });

//		client.Subscribe(new string[] { "running" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE }); 

		client.Publish ("start", System.Text.Encoding.UTF8.GetBytes ("start"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

	}

	void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e) 
	{ 


////		string value1 = System.Text.Encoding.UTF8.GetString (e.Message);
//		value1 = System.Text.Encoding.UTF8.GetString (e.Message).Split (',') [0];
//		value2 = System.Text.Encoding.UTF8.GetString (e.Message).Split (',') [1];
//
//		tiltX = Int32.Parse(value1);
//		tiltY = Int32.Parse(value2);
//
//		Debug.Log("Received: " + System.Text.Encoding.UTF8.GetString(e.Message));
//
////		Debug.Log("Received: " + value1);
////		Debug.Log("Received: " + value1 + ", " + value2);
//
////		if (values[1] != null) {
////			Debug.Log ("Received: " + values[0] + values[1]);
////		} else {
////			Debug.Log(values[0]);
////
////		}

//		if (System.Text.Encoding.UTF8.GetString (e.Message).Split (',') [0] == "yValue") {
//			value = System.Text.Encoding.UTF8.GetString (e.Message).Split (',') [1];
//			tiltY = Int32.Parse(value);
////			Debug.Log("value1: " + value);
//		} else if (System.Text.Encoding.UTF8.GetString (e.Message).Split (',') [0] == "xValue") {
//			value = System.Text.Encoding.UTF8.GetString (e.Message).Split (',') [1];
//			tiltX = Int32.Parse(value);
////			Debug.Log("value2: " + value);
//		} else if (System.Text.Encoding.UTF8.GetString (e.Message).Split (',') [0] == "switch") {
//			value = System.Text.Encoding.UTF8.GetString (e.Message).Split (',') [1];
////			Debug.Log("value2: " + value);
//		} 

		if (e.Topic.Equals("active/slider1")) {
			
//			Debug.Log("Slider 1: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			slider1 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		} else if (e.Topic.Equals("active/slider2")) {
			
//			Debug.Log("Slider 2: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			slider2 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		}  else if (e.Topic.Equals("active/slider3")) {
			
//			Debug.Log("Slider 3: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			slider3 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		}  else if (e.Topic.Equals("active/potentiometer1")) {
			
//			Debug.Log("Potentiometer 1: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			pot1 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		}  else if (e.Topic.Equals("active/potentiometer2")) {
			
//			Debug.Log("Potentiometer 2: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			pot2 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		}  else if (e.Topic.Equals("active/potentiometer3")) {

			//			Debug.Log("Potentiometer 3: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			pot3 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		}   else if (e.Topic.Equals("active/switch1")) {

			//			Debug.Log("Potentiometer 3: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			switch1 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		}  else if (e.Topic.Equals("active/switch2")) {

			//			Debug.Log("Potentiometer 3: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			switch2 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		}  else if (e.Topic.Equals("active/switch3")) {

			//			Debug.Log("Potentiometer 3: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			switch3 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		}	else if (e.Topic.Equals("active/switch4")) {

			//			Debug.Log("Potentiometer 3: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			switch4 = Int32.Parse (System.Text.Encoding.UTF8.GetString (e.Message));

		} 	else if (e.Topic.Equals("passive/hum")) {
//			Debug.Log("Humidity: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			humidity = float.Parse (System.Text.Encoding.UTF8.GetString (e.Message));
		}	 else if (e.Topic.Equals("passive/tmp")) {
//			Debug.Log("Temperature: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			temperature = float.Parse (System.Text.Encoding.UTF8.GetString (e.Message));
		} 	else if (e.Topic.Equals("passive/prs")) {
//			Debug.Log("Pressure: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
			pressure = float.Parse (System.Text.Encoding.UTF8.GetString (e.Message));
		} 	else if (e.Topic.Equals("passive/bright")) {
			Debug.Log("Brightness: " + System.Text.Encoding.UTF8.GetString(e.Message)  );
		}






	} 

	void OnGUI(){
//		if ( GUI.Button (new Rect (20,40,80,20), "Level 1")) {
////			Debug.Log("sending...");
////			client.Publish("hello/world", System.Text.Encoding.UTF8.GetBytes("Sending from Unity3D!!!"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
////			Debug.Log("sent");
//		}
	}
	// Update is called once per frame
	void Update () {

		float timer = Time.time;
		String timer2 = timer.ToString ();
		float interval = 0.5f;
		String nextTimeString = nextTime.ToString ();


		if (timer >= nextTime) {



//			client.Publish("key board/coinEject", System.Text.Encoding.UTF8.GetBytes("1"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);


//			client.Publish("Data", System.Text.Encoding.UTF8.GetBytes(leftHandPosition + "," + rightHandPosition), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

			nextTime += interval;
		}

		if (Input.GetKeyDown (KeyCode.D)) {
			client.Publish ("coinEject", System.Text.Encoding.UTF8.GetBytes ("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);

		}


		// Create Random States out of the combination of values

		if (switch1 == 0) {

//			if (pot1 + pot2 + pot3 <= 150 && slider1 + slider2 + slider3 <= 150) {
//				randPreset1 = 1;
//				randPreset2 = 2;
//			} else if (pot1 + pot2 + pot3 >= 150 && slider1 + slider2 + slider3 >= 150) {
//				randPreset1 = 2;
//				randPreset2 = 1;
//			} else if (pot1 + pot2 + pot3 <= 150 && slider1 + slider2 + slider3 >= 150) {
//				randPreset1 = 3;
//				randPreset2 = 4;
//			} else if (pot1 + pot2 + pot3 >= 150 && slider1 + slider2 + slider3 <= 150) {
//				randPreset1 = 4;
//				randPreset2 = 3;
//			}

			if (switch4 == 0) {
				if (pot1 >= 50) {
					randPreset1 = 1;
					randPreset2 = 2;
				} else {
					randPreset1 = 2;
					randPreset2 = 1;
				}
			} else {
				if (pot1 >= 50) {
					randPreset1 = 3;
					randPreset2 = 4;
				} else {
					randPreset1 = 4;
					randPreset2 = 3;
				}
			}


				
		}  else if (switch1 == 1) {



			if (switch4 == 0) {
				if (pot1 >= 50) {
					randPreset1 = 5;
					randPreset2 = 6;
				} else {
					randPreset1 = 6;
					randPreset2 = 5;
				}
			} else {
				if (pot1 >= 50) {
					randPreset1 = 7;
					randPreset2 = 8;
				} else {
					randPreset1 = 8;
					randPreset2 = 7;
				}
			}

		}



	}

	public void Eject() {
		client.Publish ("coinEject", System.Text.Encoding.UTF8.GetBytes ("0"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, true);
	}
}
