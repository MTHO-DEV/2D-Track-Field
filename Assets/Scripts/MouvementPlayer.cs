using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementPlayer : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rigidBody;
    public Animator animator;

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

        MovePlayer(horizontalMovement);

        float playerVelocity = Mathf.Abs(rigidBody.velocity.x);
        animator.SetFloat("speed", playerVelocity);
    }

    public void MovePlayer (float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidBody.velocity.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, .05f);
    }
}
