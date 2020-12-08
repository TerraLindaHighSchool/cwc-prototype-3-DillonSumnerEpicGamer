using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlPlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private Rigidbody playerRB;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticleInput = Input.GetAxis("Vertical");

        playerRB.AddForce(Vector3.forward * speed * verticleInput);
        playerRB.AddForce(Vector3.right * speed * horizontalInput);
    }
}
