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
    internal Menu(string name) 
    {
        Name = $"{nameof(Menu)}-" + name;
        Selections = new List<MenuSelection>();
    }
    public override string Name { get; protected set; }
    public override List<MenuSelection> Selections { get; protected set; }
    internal void UpdateMenuSelections(List<MenuSelection> selections)
    {
        Selections = selections;
    }
    
    internal void UpdateName(string name)
    {
        Name = name;
    }
}