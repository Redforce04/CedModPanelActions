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

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using PanelActions.Internal;

namespace PanelActions;

public abstract class ModalItem 
{
    public ModalItem()
    {
        Name = $"{nameof(ModalItem)}-";
        EnumValues = new List<string>();
    }
    public abstract ModalItemType ModalItemType { get; protected set; }
    public abstract string Name { get; protected set; }
    public abstract string Title { get; protected set; }
    public virtual string Description { get; protected set; } = "";
    public List<string> EnumValues { get; protected set; }
    [JsonIgnore]
    internal Modal Parent { get; set; }
}