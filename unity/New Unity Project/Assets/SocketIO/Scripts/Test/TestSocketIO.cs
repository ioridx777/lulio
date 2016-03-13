#region License
/*
 * TestSocketIO.cs
 *
 * The MIT License
 *
 * Copyright (c) 2014 Fabio Panettieri
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#endregion

using System.Collections;
using UnityEngine;
//using UnityEngine.UI;
using SocketIO;

public class TestSocketIO : MonoBehaviour
{
	private SocketIOComponent socket;
	
	public UnityEngine.UI.InputField nameField;
	public UnityEngine.UI.InputField contentField;
	public UnityEngine.UI.Button sendButton;
	public GameObject DialogGameObject;
	public UnityEngine.UI.Text DialogContent;
	
	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();

		socket.On("open", TestOpen);
		socket.On("error", TestError);
		socket.On("close", TestClose);
		
		socket.On("boop", TestBoop);
		socket.On("data", TestAddData);
		
		StartCoroutine("BeepBoop");
	}
	public void SendData()
	{
		if(nameField.text.Length>0&&contentField.text.Length>0)
		{
			TurnoffButton();
			SendData(nameField.text,contentField.text);
		}
	}
	public void SendData(string name,string content)
	{
		JSONObject jsonObj=new JSONObject();
		jsonObj.AddField("name",name);
		jsonObj.AddField("content",content);
		Debug.Log(jsonObj.ToString());
		socket.Emit("adddata",jsonObj);
	}
	public void TurnoffButton()
	{
		nameField.enabled=false;
		contentField.enabled=false;
		sendButton.enabled=false;
		sendButton.GetComponentInChildren<UnityEngine.UI.Text>().text="Sending";
	}
	public void TurnonButton()
	{
		nameField.enabled=true;
		contentField.enabled=true;
		sendButton.enabled=true;
		sendButton.GetComponentInChildren<UnityEngine.UI.Text>().text="Send";
	}
	private IEnumerator BeepBoop()
	{
		// wait 1 seconds and continue
		
		yield return new WaitForSeconds(1);
		
		socket.Emit("beep");
		
//		SendData("myname","mycontent");
		// wait 3 seconds and continue
		yield return new WaitForSeconds(3);
		
		socket.Emit("beep");
		
		// wait 2 seconds and continue
		yield return new WaitForSeconds(2);
		
		socket.Emit("beep");
		
		// wait ONE FRAME and continue
		yield return null;
		
		socket.Emit("beep");
		socket.Emit("beep");
	}
	
	
	public void OpenDialog(string content)
	{
		DialogGameObject.SetActive(true);
		DialogContent.text=content;
	}
	public void CloseDialog()
	{
		DialogGameObject.SetActive(false);
	}

	public void TestOpen(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Open received: " + e.name + " " + e.data);
	}
	
	public void TestBoop(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Boop received: " + e.name + " " + e.data);

		if (e.data == null) { return; }

		Debug.Log(
			"#####################################################" +
			"THIS: " + e.data.GetField("this").str +
			"#####################################################"
		);
	}
	
	public void TestError(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] Error received: " + e.name + ":" + e.data);
		
		OpenDialog("[SocketIO] Error received: " + e.name + ":" + e.data);
	}
	
	public void TestAddData(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] AddData received: " + e.name + " " + e.data);
		OpenDialog("[SocketIO] AddData received: " + e.name + " " + e.data);
		TurnonButton();
	}
	
	public void TestClose(SocketIOEvent e)
	{	
		Debug.Log("[SocketIO] Close received: " + e.name + " " + e.data);
	}
}
