// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         SelectionAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:40 AM
//    Created Date:     10/19/2023 11:40 AM
// -----------------------------------------

using PanelActions.Internal;

namespace PanelActions;

public sealed class SelectionAttribute : ActionItemAttribute
{
    public SelectionAttribute(string name, SelectionValue value)
    {
        Selection = new Selection(name, value);
    }
    internal Selection Selection { get; set; }
}