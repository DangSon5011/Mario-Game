using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pause = false;

    public GameObject pauseUI;
    private GameMaster gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        pauseUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0 ;
        }
        if (!pause)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        
    }
    public void Resume()
    {
        pause = false;
    }
    public void Restart()
    {
        gm.lastCheckPointPos = new Vector2(-11, -4);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Quit()
    {
        Application.Quit();
    }
}
