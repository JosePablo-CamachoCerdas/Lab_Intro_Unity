using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 15f; 
    public float gravity = -9.18f;
    Vector3 velocity;

    public Transform floor_check;
    public float floor_distance = 0.4f;
    public LayerMask floor_mask;
    bool is_in_floor;

    public float jump_height = 3f;
    
// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	is_in_floor = Physics.CheckSphere(floor_check.position,
					  floor_distance,
					  floor_mask);
	if(is_in_floor && velocity.y < 0){
		velocity.y = -2f;
    }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump")){
            velocity.y = Mathf.Sqrt(jump_height * -2f * gravity);
        }

       	velocity.y += gravity * Time.deltaTime;
	    controller.Move(velocity * Time.deltaTime);
    }
}
