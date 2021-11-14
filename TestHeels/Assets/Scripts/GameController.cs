using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private void Start()
    {
        PlayerController.Instance.OnFinishEvent += FinishGame;
    }

    private void FinishGame(bool finished)
    {
        Debug.Log("finished? " + finished);
    }
}
