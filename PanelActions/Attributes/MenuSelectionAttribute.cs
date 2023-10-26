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
using Newtonsoft.Json;
using PanelActions.Attributes;

namespace PanelActions;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class MenuSelectionAttribute : ActionItemAttribute
{
    public MenuSelectionAttribute(string optionName, string displayName, string description = "")
    {
        MenuSelection = new MenuSelection(optionName, displayName);
        MenuSelection.DisplayDescription = description;
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
        set => MenuSelection.DisplayName = value;
    }
    
    public override string DisplayDescription
    {
        get => MenuSelection.DisplayDescription;
        set => MenuSelection.DisplayDescription = value;
    }

}