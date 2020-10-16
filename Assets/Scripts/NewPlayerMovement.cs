using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Joystick joystick;

    public float speed = 10f;

    float HorzizontalMove = 0f;
    float VerticalMove = 0f;
    private CharacterController controller;
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //HorzizontalMove = joystick.Horizontal;
        //VerticalMove = joystick.Vertical;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);

        Vector3 move2 = new Vector3(joystick.Horizontal, 0 , joystick.Vertical);
        controller.Move(move2 * Time.deltaTime * speed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}
    }
}
