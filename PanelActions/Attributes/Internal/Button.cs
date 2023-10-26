// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Button.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 3:58 PM
//    Created Date:     10/19/2023 3:58 PM
// -----------------------------------------

namespace PanelActions.Internal;

internal sealed class Button : ButtonAction
{
    internal Button(string name, string buttonTitle)
    {
        Name = $"{nameof(Button)}-" + name;
        DisplayName = buttonTitle;
    }

    internal void UpdateDisplayName(string name)
    {
        this.DisplayName = name;
    }

    internal void UpdateDisplayDescription(string description)
    {
        this.DisplayDescription = description;
    }

    internal void UpdateName(string name)
    {
        Name = name;
    }
    public override string Name { get; protected set; }
}