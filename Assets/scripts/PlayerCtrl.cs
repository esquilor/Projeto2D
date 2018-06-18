﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour {

	public float horizontalSpeed = 5f;
	public float jumpSpeed = 600f;

	Rigidbody2D rb;
	SpriteRenderer sr;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float horizontalPlayerSpeed = horizontalSpeed * horizontalInput;
		if(horizontalSpeed != 0){
			MoveHorizontal(horizontalPlayerSpeed);
		}
		else{
			StopMoving();
		}
		if(Input.GetButtonDown("Jump")){
			jump();
		}
	}

	void MoveHorizontal(float speed){
		rb.velocity = new Vector2(speed, rb.velocity.y);
		if(speed < 0f){
			sr.flipX = true;
		}
		if(speed > 0f){
			sr.flipX = false;
		}
	}
	void StopMoving(){
		rb.velocity = new Vector2(0f, rb.velocity.y);
	}
	void jump(){
		rb.AddForce(new Vector2(0f, jumpSpeed));
	}
}
