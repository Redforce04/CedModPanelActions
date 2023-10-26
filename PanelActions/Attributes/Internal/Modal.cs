﻿// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Modal.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 3:59 PM
//    Created Date:     10/19/2023 3:59 PM
// -----------------------------------------

using System.Collections.Generic;

namespace PanelActions.Internal;

internal sealed class Modal : ModalAction
{
    internal Modal(string name, List<ModalItem> modalFields)
    {
        Name = "modal-" + name;
        ModalFields = modalFields;
    }
    
    internal void UpdateDisplayName(string name)
    {
        this.DisplayName = name;
    }

    internal void UpdateDisplayDescription(string description)
    {
        this.DisplayDescription = description;
    }
    internal void UpdateName(string name)
    {
        Name = name;
    }
    
    public override string Name { get; protected set; }
    public override List<ModalItem> ModalFields { get; protected set; }
}