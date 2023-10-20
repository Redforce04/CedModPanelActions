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

namespace PanelActions;

public class MenuSelection
{
    public MenuSelection(string name, string selectionTitle)
    {
        Name = name;
        SelectionTitle = selectionTitle;
    }
    public required string Name { get; set; }
    public required string SelectionTitle { get; set; }
}