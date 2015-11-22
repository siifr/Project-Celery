using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InventoryHandler;
public class PlayerBehavior : MonoBehaviour {

#region Script Vars
    Vector3 movement;

    Rigidbody playerRigidBody;

    int groundMask;

    float camRayLength = 1000f;

    float speed = 10f;

#endregion

	void Awake () 
    {
	    playerRigidBody = GetComponent<Rigidbody>();

        groundMask = LayerMask.GetMask("Ground");
	}

    void Start()
    {

    }

	void FixedUpdate () 
    {
        float h = Input.GetAxisRaw("Horizontal");

        float v = Input.GetAxisRaw("Vertical");

        if(!InvHandler.showInv) //If inventory is showing player cannot move
            mainMove(h, v);
	}

    void mainMove(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit groundHit;

        if (Physics.Raycast(camRay, out groundHit, camRayLength, groundMask))
        {
            Vector3 playerToMouse = groundHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            playerRigidBody.MoveRotation(newRotation);
            playerRigidBody.MovePosition(transform.position + movement);
        }
    }
}
