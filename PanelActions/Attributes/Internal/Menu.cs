// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Menu.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 3:58 PM
//    Created Date:     10/19/2023 3:58 PM
// -----------------------------------------

using System;
using System.Collections.Generic;

namespace PanelActions.Internal;

internal sealed class Menu : MenuAction
{
    internal Menu(string name, List<MenuSelection> menuSelections)
    {
        if (menuSelections is null || menuSelections.Count < 1)
        {
            throw new ArgumentException("The value \"MenuSelections\" (List<MenuSelection>) must have at least one valid menu selection.");
        }

        Name = name;
        Selections = menuSelections;
    }
    public override string Name { get; protected set; }
    public override List<MenuSelection> Selections { get; protected set; }
}