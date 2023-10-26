// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         SliderAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:40 AM
//    Created Date:     10/19/2023 11:40 AM
// -----------------------------------------

using System;
using PanelActions.Internal;

namespace PanelActions.Attributes;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public sealed class SliderAttribute : ActionItemAttribute
{
    public SliderAttribute(string name, string description = "", float defaultValue = 0f, float minimumValue = 0f, float maximumValue = 100f, bool intOnly = false)
    {
        Slider = new Slider(name, defaultValue, minimumValue, maximumValue, intOnly);
        DisplayName = name;
        DisplayDescription = description;
    }
    internal Slider Slider { get; set; }
    public override string DisplayName
    {
        get => Slider.DisplayName;
        set => Slider.DisplayName = (value);
    }
    public override string DisplayDescription
    {
        get => Slider.DisplayDescription;
        set => Slider.DisplayDescription = (value);
    }
    
    public override string Name
    {
        get => Slider.Name;
        set => Slider.UpdateName(value);
    }
}