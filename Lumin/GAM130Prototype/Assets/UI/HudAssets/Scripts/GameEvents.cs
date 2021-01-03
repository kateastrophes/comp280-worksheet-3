using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onEnterPoisenCollision;
    public void EnterPoisenCollision()
    {
        if (onEnterPoisenCollision != null)
        {
            onEnterPoisenCollision();
        }
    }

    public event Action onExitPoisenCollision;
    public void ExitPoisenCollision()
    {
        if (onExitPoisenCollision != null)
        {
            onExitPoisenCollision();
        }
    }
}
