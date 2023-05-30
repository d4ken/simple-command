using System;
using System.Collections;
using System.Collections.Generic;
using DesignPatterns.Command;
using UnityEngine;

public class Undo : AbstructButton
{
    private void Start()
    {
        OnClickCallback += () =>
        {
            Debug.Log("Undo");
            CommandInvoker.UndoCommand();
        };
    }
}
