﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {


	public static GM instance = null;

	public float yMinLive = -10f;
	public Transform spawnPoint;
	public GameObject playerPrefab;
	PlayerCtrl player;
	public float timeToResspawn = 2f;
    public UI ui;
    GameData data = new GameData();

	void Awake(){
		if(instance == null){
			instance = this;
		}
	}
	// Use this for initialization
	void Start () {
		if(player == null){
			RespawnPlayer();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null){
			GameObject obj = GameObject.FindGameObjectWithTag("Player");
			if(obj != null){
				player = obj.GetComponent<PlayerCtrl>();
			}
		}
	}
    void DisplayHudData()
    {
        ui.hud.txtCoinCount.text = "X " + data.coinCount;
    }
    public void IncrementCoinCount(){
        data.coinCount++;
    }
	public void RespawnPlayer(){
		Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

	}
	public void KillPlayer(){
		if(player != null){
			Destroy(player.gameObject);
			Invoke("RespawnPlayer", timeToResspawn);
		}

	}
}
