using UnityEngine;
using System.Collections;
using SocketIOClient;

public class TestDll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Client client =new Client("http://127.0.0.1:1337");
		client.Opened+=SocketOpened;	
//		client.Message+=SocketMessage;	

		client.SocketConnectionClosed+=SocketConnectionClosed;
		client.Error+=SocketError;
		client.Connect();
		
//		client.Send("connection");
//		client.Emit("connection",null);
//		client.Send(); message
		client.Close();
		
	}
	
	private void SocketOpened(object sender, System.EventArgs e) {
    //invoke when socket opened
		Debug.Log("Connection open "+e.ToString());
		
	}
	
//	private void SocketMessage(object sender, SocketMessage e) {
//    //invoke when socket opened
//	if ( e!= null && e.Message.Event == "message") {
//        string msg = e.Message.MessageText;
//       process(msg);
//    }
//	}
	private void SocketError(object sender, System.EventArgs e) {
    //invoke when socket opened
		Debug.Log("Error "+e.ToString());
}
	private void SocketConnectionClosed(object sender, System.EventArgs e) {
    //invoke when socket opened
		Debug.Log("Connection closed "+e.ToString());
		
}
	// Update is called once per frame
	void Update () {
	
	}
}
