﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    Controls controls;
    PlayerAbilities PA;

    public void Awake()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this); // This script will be able to use Player Action map
        
    }
    public void Start()
    {
        PA = GetComponent<PlayerAbilities>();
    }
    private void OnEnable()
    {
        controls.Player.Enable();
    }
    private void OnDisable()
    {
        controls.Player.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Jump");
            PA.SetJump();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        float direction = context.ReadValue<float>();
        Debug.Log(direction);
        PA.SetMove(context.ReadValue<float>());
    }
}
