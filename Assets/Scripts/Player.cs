using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour {

    Rigidbody2D rb;
    float angle = 0;
    int xSpeed = 3;
    int ySpeed = 30;

    GameManager gameManager;

    void Awake() {
        rb = GetComponent < Rigidbody2D > ();
        gameManager = GameObject.Find("GameManager").GetComponent < GameManager > ();
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
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
        Dead();
    }

    void Dead() {
        gameManager.GameOver();
    }
}
