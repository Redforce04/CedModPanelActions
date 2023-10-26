// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalAction.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:37 AM
//    Created Date:     10/19/2023 11:37 AM
// -----------------------------------------

using System.Collections.Generic;

namespace PanelActions;

public abstract class ModalAction : Action
{
    public ModalAction() : base() { } 

    public abstract override string Name { get; protected set; }
    public override ActionType ActionType { get; protected set; } = ActionType.Modal;
    public virtual List<ModalItem> ModalFields { get; protected set; } = new List<ModalItem>();

    public void AddModalField(ModalItem item)
    {
        if (ModalFields is null)
        {
            ModalFields = new List<ModalItem>();
        }
        ModalFields.Add(item);
    }
}