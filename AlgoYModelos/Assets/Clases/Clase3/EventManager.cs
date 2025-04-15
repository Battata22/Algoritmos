using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public static class EventManager
{

    public delegate void MyEvent(object[] parameter);

    public static MyEvent number;

    static Dictionary<string, MyEvent> events = new Dictionary<string, MyEvent>();

    public static void Suscribe(string name, MyEvent method)
    {
        if(events.ContainsKey(name))
        {
            events[name] += method;
        }
        else
        {
            events.Add(name, method);
        }
    }

    public static void Unsuscribe(string name, MyEvent method)
    {
        if (events.ContainsKey(name))
        {
            events[name] -= method;
            if (events[name] == null)
            {
                events.Remove(name);
            }
        }
    }

    public static void Trigger(string name, params object[] parameters)
    {
        if (events.ContainsKey(name))
        {
            events[name](parameters);
        }
    }
}
