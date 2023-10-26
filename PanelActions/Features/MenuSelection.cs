// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         MenuType.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:49 AM
//    Created Date:     10/19/2023 11:49 AM
// -----------------------------------------

using System.ComponentModel.DataAnnotations;

namespace PanelActions;

public class MenuSelection
{
    public MenuSelection(string name, string displayName)
    {
        Name = name;
        DisplayName = displayName;
    }

    internal void AssignMenuAction(MenuAction action)
    {
        MenuAction = action;
    }
    public MenuAction MenuAction { get; private set; }
    public string Name { get; set; }
    public string DisplayName { get; private set; }
    public string DisplayDescription { get; private set; }
    public void UpdateDisplayName(string name)
    {
        this.DisplayName = name;
    }

    public void UpdateDisplayDescription(string description)
    {
        this.DisplayDescription = description;
    }
}