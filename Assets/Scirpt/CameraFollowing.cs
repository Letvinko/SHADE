using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour {

    public Transform player;

    Vector3 velocity = Vector3.zero;

    public float smoothTime = .15f;
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetPost = player.position;

        targetPost.z = transform.position.z;

        transform.position = Vector3.SmoothDamp(transform.position,targetPost,ref velocity,smoothTime);
		
	}
}
