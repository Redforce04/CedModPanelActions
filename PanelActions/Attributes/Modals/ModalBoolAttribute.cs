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

public sealed class ModalBoolAttribute : ModalItemAttribute
{
    public ModalBoolAttribute(string name, string description = "", bool enabledByDefault = false) : base(name, description)
    {
        Item = new ModalBool(name, name, description, enabledByDefault);
        ItemType = ModalItemType.Bool;
    }
}