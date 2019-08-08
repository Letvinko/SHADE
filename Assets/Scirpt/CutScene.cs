using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour {
    public Animator transition;
    public string next;



    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(SceneTransition());
	}

    IEnumerator SceneTransition() {
        transition.SetTrigger("end");
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(next);
    }
}
