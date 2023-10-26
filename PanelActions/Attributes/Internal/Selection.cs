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
    internal Selection(string name, SelectionValue value, bool allowMultiple = false)
    {
        Name =  $"{nameof(Selection)}-" + name;
        AllowMultiple = allowMultiple;
    }
    internal void UpdateName(string name)
    {
        Name = name;
    }

    public override string Name { get; protected set; }
    public override SelectionValue SelctionValue { get; protected set; }
    public override bool AllowMultiple { get; protected set; } = false;

    public void UpdateAllowMultiple(bool allowMultiple)
    {
        AllowMultiple = allowMultiple;
    }
}
