// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         SelectionAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:40 AM
//    Created Date:     10/19/2023 11:40 AM
// -----------------------------------------

using System;
using PanelActions.Internal;

namespace PanelActions.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Enum, AllowMultiple = false, Inherited = true)]
public sealed class SelectionAttribute : ActionItemAttribute
{
    public SelectionAttribute(string name, string description = "", SelectionValue value = SelectionValue.AutoSelect, bool allowMultiple = false)
    {
        Selection = new Selection(name, value, allowMultiple);
        DisplayName = name;
        DisplayDescription = description;
    }
    internal Selection Selection { get; set; }
    public override string DisplayName
    {
        get => Selection.DisplayName;
        set => Selection.DisplayName = (value);
    }
    public override string DisplayDescription
    {
        get => Selection.DisplayDescription;
        set => Selection.DisplayDescription = value;
    }
    
    public override string Name
    {
        get => Selection.Name;
        set => Selection.UpdateName(value);
    }
}