using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public float speed;

    private Vector3 currentPost;

    private Vector3 nextPost;

    private Vector3 FinalPost;

    [SerializeField]
    private Transform postAwal;

    [SerializeField]
    private Transform postFinal;

    [SerializeField]
    private LayerMask platformer;

    private bool cekBawah;

	// Use this for initialization
	void Start () {
        currentPost = postAwal.localPosition;
        FinalPost = postFinal.localPosition;
        nextPost = FinalPost;
	}
	
	// Update is called once per frame
	void Update () {
        MovePlatform();        
    }

    public void MovePlatform() {
        postAwal.localPosition = Vector3.MoveTowards(postAwal.localPosition, nextPost, speed * Time.deltaTime);

        if (Vector3.Distance(postAwal.localPosition,nextPost) <= 0.1) {
            changeDest();
        }
    }

    public void changeDest() {
        nextPost = nextPost != currentPost ? currentPost : FinalPost;            
    }

}
