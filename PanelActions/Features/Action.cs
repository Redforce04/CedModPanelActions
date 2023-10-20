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

namespace PanelActions;

public abstract class Action
{
    public virtual string Name { get; protected set; }
    public abstract ActionType ActionType { get; protected set; }
    
    
}
