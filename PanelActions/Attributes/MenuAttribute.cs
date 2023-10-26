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

namespace PanelActions.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class MenuAttribute : ActionItemAttribute
{
    public MenuAttribute(string name)
    {
        Menu = new Menu(name);
    }
    internal Menu Menu { get; set; }

    internal void UpdateMenuOptions(List<MenuSelection> selections)
    {
        Menu.UpdateMenuSelections(selections);
    }
    public override string DisplayName
    {
        get => Menu.DisplayName;
        set => Menu.UpdateDisplayName(value);
    }
    public override string DisplayDescription
    {
        get => Menu.DisplayDescription;
        set => Menu.UpdateDisplayDescription(value);
    }

    public override string Name
    {
        get => Menu.Name;
        set => Menu.UpdateName(value);
    }
}