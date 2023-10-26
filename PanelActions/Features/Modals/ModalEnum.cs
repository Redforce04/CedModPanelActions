// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalEnum.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:57 AM
//    Created Date:     10/19/2023 11:57 AM
// -----------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelActions;

public sealed class ModalEnum : ModalItem
{
    public override ModalItemType ModalItemType { get; protected set; } = ModalItemType.Enum;
    public ModalEnum(string name, string title, Type enumType, object placeholderValue = null, string description = "")
    {
        Name = $"{nameof(ModalEnum)}-{name}";
        Title = title;
        Description = description;
        EnumType = enumType;
        Values = Enum.GetValues(enumType).OfType<string>().ToList();
        // Placeholder
        if (placeholderValue is Enum enumVal)
        {
            PlaceholderValue = enumVal.ToString();
        }

        if (placeholderValue is string strVal)
        {
            try
            {
                var result = Enum.Parse(enumType, strVal, true);
                PlaceholderValue = result.ToString();
            }
            catch (Exception e)
            {
                return;
            }
        }
    }
    public override string Name { get; protected set; }
    public override string Title { get; protected set; }
    public override string Description { get; protected set; }
    public string PlaceholderValue { get; internal set; } = "";
    public Type EnumType { get; private set; }
    public List<string> Values { get; private set; }
}