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

public sealed class ModalStringAttribute : ModalItemAttribute
{
    public ModalStringAttribute(string name, string description = "", 
        string placeholder = "", 
        string regexFilter = "") : base(name, description)
    {
        Item = new ModalString(name, name, description, placeholder, regexFilter);
        ItemType = ModalItemType.String;
    }
}