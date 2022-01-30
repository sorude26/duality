using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager 
{
    public static event Action OnChangeTimeZone;
    public static void ChangeTimeZone()
    {
        OnChangeTimeZone?.Invoke();
    }
}
