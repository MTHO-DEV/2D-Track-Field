using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprinterManager : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public Animator animator;

    private Vector3 velocity = Vector3.zero;
    private double impulsion = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (impulsion > 0)
        {
            impulsion -= 0.1;
        }
        else
        {
            impulsion = 0;
        }
        double horizontalMovement = impulsion * speed * Time.deltaTime;

        _MovePlayer((float)horizontalMovement);

        float playerVelocity = Mathf.Abs(rigidBody.velocity.x);
        animator.SetFloat("speed", playerVelocity);
    }

    void _MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rigidBody.velocity.y);
        rigidBody.velocity = Vector3.SmoothDamp(rigidBody.velocity, targetVelocity, ref velocity, .05f);
    }

    public void run()
    {
        impulsion += 4;
    }

    public void ResetPlayerPosition()
    {
        // Changer la position du joueur
        transform.position = new Vector3(0, 0, 0);

    }
}
