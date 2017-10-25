using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float SpeedRotation;
    [SerializeField]
    float gravity;
    float horizontal;
    float vertical;
    [SerializeField]
    Camera cameras;
    Vector3 moveHorizontal;
    Vector3 moveForward;
    Vector3 moveDirection;
    CharacterController controller;
    [SerializeField] [SyncVar] int playerID = -1;

    public int PlayerID
    {
        get
        {
            return playerID;
        }

        set
        {
            playerID = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            //mouvement de la caméra avec la souris
            transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * SpeedRotation);
            cameras.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y"), 0, 0) * Time.deltaTime * SpeedRotation);

            moveHorizontal = transform.right * speed * horizontal;
            moveForward = transform.forward * speed * vertical;

            if (controller.isGrounded == false)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            controller.Move(moveDirection);
            controller.SimpleMove(moveHorizontal + moveForward);
      
        
    }
    // change de couleur les joueurs
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
        cameras.gameObject.SetActive(true);
    }

    [ServerCallback]

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
        }
    }
}
