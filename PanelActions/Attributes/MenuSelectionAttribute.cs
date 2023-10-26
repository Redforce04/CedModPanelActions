// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         MenuSelectionAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/25/2023 1:15 PM
//    Created Date:     10/25/2023 1:15 PM
// -----------------------------------------

using System;
using PanelActions.Attributes;

namespace PanelActions;

[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
public class MenuSelectionAttribute : ActionItemAttribute
{
    public MenuSelectionAttribute()
    {
        MenuSelection = new MenuSelection("", "");
    }
    public MenuSelection MenuSelection { get; set; }

    public override string Name
    {
        get => MenuSelection.Name;
        set => MenuSelection.Name = value;
    }

    public override string DisplayName
    {
        get => MenuSelection.DisplayName;
        set => MenuSelection.UpdateDisplayName(value);
    }
    public override string DisplayDescription
    {
        get => MenuSelection.DisplayDescription;
        set => MenuSelection.UpdateDisplayDescription(value);
    }

}