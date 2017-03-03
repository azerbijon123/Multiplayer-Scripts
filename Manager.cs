using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : Photon.MonoBehaviour {

	public GameObject[] redSpawns;
	public GameObject[] blueSpawns;
	public GameObject lobbyCam;

	int state = 0;
	public int maxPlayers;

	// Use this for initialization
	void Start () {
		state = 0;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		switch (state) {
		//Start
		case 0:
			if (GUI.Button (new Rect (10, 10, 200, 30), "Connect")) {
				PhotonNetwork.ConnectUsingSettings ("V0.0");
				state = 4;
			}
			break;
		//Connected to Server
		case 1:
			if (GUI.Button (new Rect (10, 10, 300, 30), "The Missing Mage (Classic)")) {
				PhotonNetwork.JoinLobby ();
				state = 4;
			}
			break;
		//Connected to Lobby
		case 2:
			
			if (GUI.Button (new Rect (10, 10, 200, 30), "Find Match")) {
				
				PhotonNetwork.JoinRandomRoom ();
			}
			break;
		//Connected to Room
		case 3:
			break;
		//Break
		case 4:
			break;
		//Matchmaking
		case 5:

			GUI.Label (new Rect (10, Screen.height - 50, 200, 30), "Players: " + PhotonNetwork.playerList.Length.ToString () + "/" + maxPlayers);

			if (PhotonNetwork.inRoom != true) {
				Debug.Log ("not in a room yet");

			}

			if (PhotonNetwork.inRoom == true && PhotonNetwork.playerList.Length == maxPlayers) {
				Debug.Log ("In room and max players = playerlist.Length");
				StartGame ();
				state = 3;
			}
			break;
			
		}
	}

	void OnConnectedToPhoton()
	{
		state = 1;
		Debug.Log ("Connected using settings");
	}

	void OnJoinedLobby()
	{
		state = 2;
		Debug.Log ("Joined Lobby");
	}

	void OnPhotonCreateGameFailed(){
		Debug.Log ("Creating Room Failed");
	}

	void OnPhotonRandomJoinedFailed()
	{
		PhotonNetwork.CreateRoom (null);
		Debug.Log ("Created new room");
	}

	void StartGame() 
	{
		Debug.Log ("Starting Game...");
	}


	/*Pointless Right Now*/
	void Spawn(int team, string character)
	{
		lobbyCam.SetActive(false);
		//PhotonNetwork.Instantiate (character);
		Debug.Log ("You are on team: " + team + ". And are playing as " + character);
	}
}
