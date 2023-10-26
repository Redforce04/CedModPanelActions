// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:40 AM
//    Created Date:     10/19/2023 11:40 AM
// -----------------------------------------

using System;
using System.Collections.Generic;
using PanelActions.Internal;

namespace PanelActions.Attributes;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public sealed class ModalAttribute : ActionItemAttribute
{
    // todo - make this auto-generate the modal fields with the method's parameters whenever this constructor is called.
    public ModalAttribute(string name)
    {
        Modal = new Modal(name, new List<ModalItem>());
        Name = name;
    }

    public ModalAttribute(string name, List<ModalItem> items)
    {
        if (items is null)
        {
            items = new List<ModalItem>();
        }
        Modal = new Modal(name, items);
    }
    internal Modal Modal { get; set; }
    public override string DisplayName
    {
        get => Modal.DisplayName;
        set => Modal.UpdateDisplayName(value);
    }
    public override string DisplayDescription
    {
        get => Modal.DisplayDescription;
        set => Modal.UpdateDisplayDescription(value);
    }
    
    public override string Name
    {
        get => Modal.Name;
        set => Modal.UpdateName(value);
    }
}