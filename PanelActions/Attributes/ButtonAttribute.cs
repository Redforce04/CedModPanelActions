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

using System;
using PanelActions.Internal;

namespace PanelActions.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class ButtonAttribute : ActionItemAttribute
{
    public ButtonAttribute(string name, string description = "")
    {
        Button = new Button(name, name);
        DisplayName = name;
        DisplayDescription = description;
    }
    internal Button Button { get; set; }
    public override string DisplayName
    {
        get => Button.DisplayName;
        set => Button.DisplayName =(value);
    }
    public override string DisplayDescription
    {
        get => Button.DisplayDescription;
        set => Button.DisplayDescription =(value);
    }

    public override string Name
    {
        get => Button.Name;
        set => Button.UpdateName(value);
    }
}