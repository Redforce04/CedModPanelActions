// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalItem.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:57 AM
//    Created Date:     10/19/2023 11:57 AM
// -----------------------------------------

namespace PanelActions;

public abstract class ModalItem 
{
    public abstract ModalItemType ModalItemType { get; protected set; }
    public abstract string Name { get; protected set; }
    public abstract string Title { get; protected set; }
    public virtual string Description { get; protected set; } = "";
}