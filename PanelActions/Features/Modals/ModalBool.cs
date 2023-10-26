// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalBool.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:58 AM
//    Created Date:     10/19/2023 11:58 AM
// -----------------------------------------

namespace PanelActions;

public sealed class ModalBool : ModalItem
{
    public override ModalItemType ModalItemType { get; protected set; } = ModalItemType.Bool;
    public ModalBool(string name, string title, string description = "", bool enabledByDefault = false)
    {
        Name = $"{nameof(ModalBool)}-{name}";
        Title = title;
        Description = description;
        EnabledByDefault = enabledByDefault;
    }
    public override string Name { get; protected set; }
    public override string Title { get; protected set; }
    public override string Description { get; protected set; }
    public bool EnabledByDefault { get; private set; }
}