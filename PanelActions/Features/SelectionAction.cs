// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         SelectionAction.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:39 AM
//    Created Date:     10/19/2023 11:39 AM
// -----------------------------------------

using System.Collections.Generic;

namespace PanelActions;

public abstract class SelectionAction : Action
{
    public SelectionAction() : base() { } 

    public abstract override string Name { get; protected set; }
    public override ActionType ActionType { get; protected set; } = ActionType.Selection;
    public abstract SelectionValue SelctionValue { get; protected set; }
    
}