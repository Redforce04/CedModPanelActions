// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ActionAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:28 AM
//    Created Date:     10/19/2023 11:28 AM
// -----------------------------------------

using PanelActions.Internal;

namespace PanelActions;

public sealed class ButtonAttribute : ActionItemAttribute
{
    public ButtonAttribute(string name, string buttonTitle)
    {
        Button = new Button(name, buttonTitle);
    }
    internal Button Button { get; set; }
}