﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player:MonoBehaviour {

    public GameObject deadEffectObj;

    Rigidbody2D rb;
    float angle = 0;
    int xSpeed = 3;
    int ySpeed = 30;

    GameManager gameManager;

    bool isDead = false;

    void Awake() {
        rb = GetComponent < Rigidbody2D > ();
        gameManager = GameObject.Find("GameManager").GetComponent < GameManager > ();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (isDead == true)return;
        movePlayer();
        getInput();
    }

    void movePlayer() {
        Vector2 pos = transform.position;
        pos.x = Mathf.Cos(angle) * 3;
        // pos.y = 0;
        transform.position = pos;
        angle += Time.deltaTime * xSpeed;
    }

    void getInput() {
        if (Input.GetMouseButton(0)) {
            rb.AddForce(new Vector2(0, ySpeed));
        }
        else {
            if (rb.velocity.y > 0) {
                rb.AddForce(new Vector2(0,  - ySpeed));
            }
            else {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }

        }
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle"){
            Dead();
        }
        else if(other.gameObject.tag == "Item") {
            Debug.Log("Score +1");
            gameManager.AddScore();
        }
    }

    void Dead() {
        isDead = true;

        Destroy(Instantiate(deadEffectObj, transform.position, Quaternion.identity), 0.5f);
        StopPlayer();
        gameManager.CallGameOver();
    }

    void StopPlayer() {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}
