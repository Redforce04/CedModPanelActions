// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Action.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:27 AM
//    Created Date:     10/19/2023 11:27 AM
// -----------------------------------------

using System;
using Newtonsoft.Json;
using PanelActions.CallbackResults.Handlers;

namespace PanelActions;

public abstract class Action
{
    public Action()
    {
        if(AutoRegister)
            this.RegisterAction();
    }
    public string DisplayName { get; internal set; }
    public string DisplayDescription { get; internal set; }
    [JsonIgnore]
    public bool AutoRegister { get; protected set; } = true;
    public virtual string Name { get; protected set; }
    public abstract ActionType ActionType { get; protected set; }
    [JsonIgnore]
    internal Handler Handler { get; set; }

}
