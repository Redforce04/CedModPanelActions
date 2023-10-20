// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalSlider.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:58 AM
//    Created Date:     10/19/2023 11:58 AM
// -----------------------------------------

namespace PanelActions;

public sealed class ModalSlider : ModalItem
{
    public override ModalItemType ModalItemType { get; protected set; } = ModalItemType.Slider;

    public ModalSlider(string name, string title, string description = "", 
        float startingValue = 0,
        float minimumValue = 0,
        float maximumValue = 100, 
        bool isInt = false)
    {
        Name = name;
        Title = title;
        Description = description;
        StartingValue = startingValue;
        MinimumValue = minimumValue;
        MaximumValue = maximumValue;
        IsInt = isInt;
    }

    public override string Name { get; protected set; }
    public override string Title { get; protected set; }
    public override string Description { get; protected set; }
    public float StartingValue { get; private set; }
    public float MinimumValue { get; private set; }
    public float MaximumValue { get; private set; }
    public bool IsInt { get; private set; }
}