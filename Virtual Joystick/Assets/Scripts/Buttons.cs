using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject panel;

    // Fields for time stuff.
    [SerializeField] float goldTime, silverTime, startTime;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivatePauseMenu()
    {
        panel.SetActive(!panel.activeSelf);
        if (panel.activeSelf)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Increase the player's money according to how fast
    // he finished the level.
    public void Victory()
    {
        float duration = Time.time - startTime;
        if (duration < goldTime)
            GameManager.instance.simdiki += 50;
        else if (duration < silverTime)
            GameManager.instance.simdiki += 25;
        else
            GameManager.instance.simdiki += 5;

        GameManager.instance.Save();
        string saveString = "";
        saveString += duration.ToString();
        saveString += '&';
        saveString += silverTime.ToString();
        saveString += '&';
        saveString += goldTime.ToString();
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, saveString);
    }
}
