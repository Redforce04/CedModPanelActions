// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalItemAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/26/2023 12:00 PM
//    Created Date:     10/26/2023 12:00 PM
// -----------------------------------------

using System;
using System.Collections.Generic;

namespace PanelActions.Attributes.Modals;


[AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
public class ModalItemAttribute : Attribute
{
    public ModalItemAttribute(string name, string description = "")
    {
        DisplayName = name;
        DisplayDescription = description;
        // ItemType = ItemType ?? ModalItemType.AutoAssign;
        EnumValues = EnumValues ?? new List<string>();
    }
    public ModalItem Item { get; internal set; }
    public string DisplayName { get; internal set; }
    public string DisplayDescription { get; internal set; }
    public ModalItemType ItemType { get; internal set; }
    public List<string> EnumValues { get; internal set; }
}