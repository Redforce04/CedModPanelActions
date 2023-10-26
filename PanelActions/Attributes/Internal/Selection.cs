// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Selection.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 3:59 PM
//    Created Date:     10/19/2023 3:59 PM
// -----------------------------------------

namespace PanelActions.Internal;

internal sealed class Selection : SelectionAction
{
    internal Selection(string name, SelectionValue value)
    {
        Name =  $"{nameof(Selection)}-" + name;
    }
    
    internal void UpdateDisplayName(string name)
    {
        this.DisplayName = name;
    }

    internal void UpdateDisplayDescription(string description)
    {
        this.DisplayDescription = description;
    }
    internal void UpdateName(string name)
    {
        Name = name;
    }

    public override string Name { get; protected set; }
    public override SelectionValue SelctionValue { get; protected set; }
}
