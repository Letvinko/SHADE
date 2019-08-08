using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Quity());
	}

    IEnumerator Quity() {
        yield return new WaitForSeconds(18f);
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Quit");
    }
}
