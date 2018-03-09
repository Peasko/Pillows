using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;

    private Animator anim;
    private bool playerMoving;
    private Vector2 lastMove;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        playerMoving = false;

        //TODO wtf 0.5f? asi ze drzi do prava ale podla mna to je == 1
		if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //Time.deltaTime sa pouziva koli tomu, ze ak hraci hraju na roznych frame ratoch aby pohyb za jednotku casu (napr. 1s) bol
            //u vsetkych rovnaky, teda aby hrac presiel rovnaku vzdialenost aj pri roznom fps
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        //TODO shouldn't be lastMove variable declared before if statements?
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
	}
}
