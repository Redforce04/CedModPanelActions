// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         SliderAction.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:36 AM
//    Created Date:     10/19/2023 11:36 AM
// -----------------------------------------

namespace PanelActions;

public abstract class SliderAction : Action
{
    public SliderAction() : base() { } 

    public abstract override string Name { get; protected set; }
    public override ActionType ActionType { get; protected set; } = ActionType.Slider;
    public virtual bool IntOnly { get; protected set; } = false;
    public virtual float MinimumValue { get; protected set; } = 0;
    public virtual float MaximumValue { get; protected set; } = 100;
    public virtual float DefaultValue { get; protected set; } = 0;
}