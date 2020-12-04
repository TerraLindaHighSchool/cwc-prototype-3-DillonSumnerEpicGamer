using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody plrRB;
    private bool isGrounded = true;
    private Animator plrAnim;
    private AudioSource plrAudio;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    public ParticleSystem explosion;
    public ParticleSystem dirt;
    public bool gameOver = false;
    public float jumpForce = 10.0f;
    public float gravityModifier;

    // Start is called before the first frame update
    void Start()
    {
        plrRB = GetComponent<Rigidbody>();
        plrAnim = GetComponent<Animator>();
        plrAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            plrRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            plrAnim.SetTrigger("Jump_trig");
            dirt.Stop();
            plrAudio.PlayOneShot(jumpSound,1.0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            dirt.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over: " + gameOver);
            plrAnim.SetBool("Death_b", true);
            plrAnim.SetInteger("DeathType_int", 1);
            explosion.Play();
            dirt.Stop();
            plrAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
