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

using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelActions.Attributes.Modals;

public sealed class ModalEnumAttribute : ModalItemAttribute
{
    public ModalEnumAttribute(Type type, string name, string description = "", string placeholderValue = "") : base(name, description)
    {
        base.ItemType = ModalItemType.Enum;
        if (!type.IsEnum)
        {
            Logging.Log($"Cannot register modal enum of type {type} because it is not an enum.", LogLevel.Warn);
            return;
        }
        EnumValues = Enum.GetNames(type).ToList();
        Item = new ModalEnum(name, name, type, description, placeholderValue);
    }
}