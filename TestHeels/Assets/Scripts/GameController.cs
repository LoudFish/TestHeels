using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public InputController inputController;

    private void Start()
    {
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
