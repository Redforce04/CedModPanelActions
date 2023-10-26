// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         MethodHandler.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/26/2023 12:16 PM
//    Created Date:     10/26/2023 12:16 PM
// -----------------------------------------

using System;
using System.Collections.Generic;
using System.Reflection;

namespace PanelActions.CallbackResults.Handlers;

internal sealed class MethodHandler : Handler
{
    internal MethodHandler(MethodInfo methodInfo, object instance)
    {
        MethodInfo = methodInfo;
        Instance = instance;
        CallbackArguments = new List<CallbackArguments>();
        foreach (var parameter in methodInfo.GetParameters())
        {
            CallbackArguments.Add(new CallbackArguments());   
        }
    }
    internal override void HandleCallback(Callback callback)
    {
        switch (callback)
        {
            case MenuCallback:
                break;
            /*case ButtonCallback:
                MethodInfo.Invoke(Instance,new[] {  });*/
                
        }
        // MethodInfo.Invoke(Instance,new[] {  });
    }
    internal MethodInfo MethodInfo { get; set; }
    internal object Instance { get; set; }
    internal List<CallbackArguments> CallbackArguments { get; set; }
}

internal struct CallbackArguments
{
    internal Type Type { get; set; } 
    internal string ArgumentName { get; set; }
}