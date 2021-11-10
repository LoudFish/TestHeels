using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private bool _touchStart = false;
    private Vector3 _touchPont;

    private bool _mouseMoving = false;
    private float _horizontalMouseDirection;
    private int _mouseMovingDirection;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _touchStart = true;

            if (Input.mousePosition != _touchPont)
            {
                _touchPont = Input.mousePosition;

                _mouseMoving = true;
            }
            else _mouseMoving = false;

            _horizontalMouseDirection = Input.GetAxisRaw("Mouse X");

            if (_horizontalMouseDirection > 0)
            {
                _mouseMovingDirection = 1;
            }
            else if (_horizontalMouseDirection < 0)
            {
                _mouseMovingDirection = -1;
            }
        }
        else _touchStart = false;
    }

    private void FixedUpdate()
    {
        if (_touchStart && _mouseMoving) PlayerController.Instance.Move(_mouseMovingDirection);
    }
}
