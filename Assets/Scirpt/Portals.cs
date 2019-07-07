using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portals : MonoBehaviour {
    public GameObject portal;
    public GameObject player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds (1);
        player.transform.position = new Vector2(portal.transform.position.x , portal.transform.position.y);
    }
}
