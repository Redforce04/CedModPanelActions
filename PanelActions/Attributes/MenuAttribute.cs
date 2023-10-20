// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         MenuAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:40 AM
//    Created Date:     10/19/2023 11:40 AM
// -----------------------------------------

using System;
using System.Collections.Generic;
using PanelActions.Internal;

namespace PanelActions;

public sealed class MenuAttribute : ActionItemAttribute
{
    public MenuAttribute(string name, List<MenuSelection> menuSelections)
    {
        if (menuSelections is null || menuSelections.Count < 1)
        {
            throw new ArgumentException("The value \"MenuSelections\" (List<MenuSelection>) must have at least one valid menu selection.");
        }

        Menu = new Menu(name, menuSelections);
    }
    internal Menu Menu { get; set; }
}