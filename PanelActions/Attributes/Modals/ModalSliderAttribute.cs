// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalBoolAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/26/2023 1:37 PM
//    Created Date:     10/26/2023 1:37 PM
// -----------------------------------------

namespace PanelActions.Attributes.Modals;

public sealed class ModalSliderAttribute : ModalItemAttribute
{
    public ModalSliderAttribute(string name, string description = "",
        float startingValue = 0,
        float minimumValue = 0,
        float maximumValue = 100, 
        bool isInt = false) : base(name, description)
    {
        Item = new ModalSlider(name, name, description, startingValue, minimumValue, maximumValue, isInt);
        ItemType = ModalItemType.Slider;
    }
}