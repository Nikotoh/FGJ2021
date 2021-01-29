using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource audioSource;
    Rigidbody2D myRB;
    Animator anim;

    float horizontal;
    float vertical;

    public float moveSpeed = 20.0f;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        Animate();

        if (myRB.velocity.magnitude >= 0.01f || myRB.velocity.magnitude >= 0.01f || myRB.velocity.magnitude <= -0.01f || myRB.velocity.magnitude <= -0.01f)
        {
            isMoving = true;
            if (!isMoving)
            {
                audioSource.Stop();
            }
        }
        else if (myRB.velocity.magnitude == 0 || myRB.velocity.magnitude == 0)
        {
            audioSource.Play();
            isMoving = false;
        }
    }

    private void FixedUpdate()
    {
        myRB.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);

    }

    void Animate()
    {
        anim.SetFloat("Horizontal", horizontal);
        anim.SetFloat("Vertical", vertical);
    }
}
