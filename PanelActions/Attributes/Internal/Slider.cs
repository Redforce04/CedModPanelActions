// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Slider.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 3:59 PM
//    Created Date:     10/19/2023 3:59 PM
// -----------------------------------------

namespace PanelActions.Internal;

internal sealed class Slider : SliderAction
{
    internal Slider(string name, float defaultValue = 0, float minimumValue = 0f, float maximumValue = 100f, bool intOnly = false)
    {
        Name = name;
        DefaultValue = defaultValue;
        MinimumValue = minimumValue;
        MaximumValue = maximumValue;
        IntOnly = intOnly;
    }
    public override string Name { get; protected set; }
    public override float MinimumValue { get; protected set; }
    public override float MaximumValue { get; protected set; }
    public override bool IntOnly { get; protected set; }
    public override float DefaultValue { get; protected set; }
}