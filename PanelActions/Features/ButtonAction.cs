﻿// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ButtonAction.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:39 AM
//    Created Date:     10/19/2023 11:39 AM
// -----------------------------------------

using PanelActions.CallbackResults.Handlers;

namespace PanelActions;

public abstract class ButtonAction : Action
{
    public ButtonAction() : base() { } 
    public abstract override string Name { get; protected set; }
    public override ActionType ActionType { get; protected set; } = ActionType.Button;
}