using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    public static bool gameispaused = false;
    public GameObject pausemenu;
    public string nameScene;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameispaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
		
	}

    public void Resume() {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        gameispaused = false;
    }

    void Pause() {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
        gameispaused = true;
    }

    public void loadMenu() {
        Debug.Log("Menu");
        SceneManager.LoadScene(nameScene);
    }

    public void QuitMenu() {
        Debug.Log("Quit");
        Application.Quit();
    }
}
