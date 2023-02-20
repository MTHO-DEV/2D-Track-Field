using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    public float timeOffset;
    public Vector3 positionOffset;

    private Vector3 velocity = Vector3.zero;


    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + positionOffset, ref velocity, timeOffset);
        //transform.position = player.transform.position + new Vector3(0,0,-10);
    }
}
