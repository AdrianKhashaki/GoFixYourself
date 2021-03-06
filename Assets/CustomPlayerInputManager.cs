﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomPlayerInputManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerNumber;
    public float DirectionalInput;

    private bool red = false;
    private bool green = false;
    private bool blue = false;
    private bool yellow = false;
    private Vector2 movement = Vector2.zero;

    public void Red(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            red = true;
            foreach(var input in getCustomPlayerInputs())
            {
                input.inputDown(PartColor.Red);
            }
        }
        if (context.canceled)
        {
            red = false;
            foreach (var input in getCustomPlayerInputs())
            {
                input.inputUp(PartColor.Red);
            }
        }
    }

    public void Blue(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            blue = true;
            foreach (var input in getCustomPlayerInputs())
            {
                input.inputDown(PartColor.Blue);
            }
        }
        if (context.canceled)
        {
            blue = false;
            foreach (var input in getCustomPlayerInputs())
            {
                input.inputUp(PartColor.Blue);
            }
        }
    }

    public void Green(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            green = true;
            foreach (var input in getCustomPlayerInputs())
            {
                input.inputDown(PartColor.Green);
            }
        }
        if (context.canceled)
        {
            green = false;
            foreach (var input in getCustomPlayerInputs())

            {
                input.inputUp(PartColor.Green);
            }
        }
    }

    public void Yellow(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            yellow = true;
            foreach (var input in getCustomPlayerInputs())
            {
                input.inputDown(PartColor.Yellow);
            }
        }
    
        if (context.canceled)
        {
            yellow = false;
            foreach (var input in getCustomPlayerInputs())
            {
                input.inputUp(PartColor.Yellow);
            }
        }
    }

    public void Movement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var input in getCustomPlayerInputs())
        {
            input.inputActive(PartColor.Red, red);
            input.inputActive(PartColor.Yellow, yellow);
            input.inputActive(PartColor.Blue, blue);
            input.inputActive(PartColor.Green, green);
            input.inputMovement(movement);
            AddDirectionalInput(input);
        }
    }

    private void AddDirectionalInput(CustomPlayerInput input)
    {
        var rigidBody = input.GetComponent<Rigidbody2D>();
        if (rigidBody != null)
        {
            rigidBody.AddForce(movement * DirectionalInput * rigidBody.mass);
            return;
        }

        foreach (var childRigidBody in input.GetComponentsInChildren<Rigidbody2D>())
        {
            childRigidBody.AddForce(movement * DirectionalInput * childRigidBody.mass);
        }
    }

    private IEnumerable<CustomPlayerInput> getCustomPlayerInputs()
    {
        return FindObjectsOfType<CustomPlayerInput>()
            .Where(input => input.GetPlayerAffinity() == playerNumber);
    }

    private void Awake()
    {

    }
}
