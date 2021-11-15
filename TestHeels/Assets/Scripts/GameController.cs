using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public InputController inputController;
    public HeelsMechanics heelsMechanics;

    public Text levelIndexText;

    private void Start()
    {
        float levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        levelIndexText.text = "Level " + levelIndex.ToString();

        PlayerController.Instance.OnFinishEvent += FinishGame;
        inputController.OnFirstInputEvent += StartGame;
        heelsMechanics.OnDeathEvent += PlayerLose;
    }

    private void StartGame(bool started)
    {
        playerController.enabled = true;
    }

    private void FinishGame(bool finished)
    {
        if (finished) Invoke("LoadNextScene", 3f);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void PlayerLose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
