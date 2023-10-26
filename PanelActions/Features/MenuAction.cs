// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ListAction.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:35 AM
//    Created Date:     10/19/2023 11:35 AM
// -----------------------------------------

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PanelActions;

public abstract class MenuAction : Action
{
    public MenuAction() : base() { } 

    public override string Name { get; protected set; }
    public override ActionType ActionType { get; protected set; } = ActionType.Menu;
    public abstract List<MenuSelection> Selections { get; protected set; }
}