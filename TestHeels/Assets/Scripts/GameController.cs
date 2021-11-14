using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public InputController inputController;
    public Text levelIndexText;

    private void Start()
    {
        float levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
        levelIndexText.text = "Level " + levelIndex.ToString();

        PlayerController.Instance.OnFinishEvent += FinishGame;
        inputController.OnFirstInputEvent += StartGame;
    }

    private void StartGame(bool started)
    {
        playerController.enabled = true;
        //PlayerController.Instance.gameObject.GetComponent<PlayerController>().enabled = true;
    }

    private void FinishGame(bool finished)
    {
        //Debug.Log("finished? " + finished);
    }
}
