// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalItemResult.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 4:21 PM
//    Created Date:     10/19/2023 4:21 PM
// -----------------------------------------

namespace PanelActions.Features.ModalResults;

public class ModalItemResult
{
    internal ModalItemResult(string name)
    {
        Name = name; 
    }
    public string Name { get; private set; }
    public virtual ModalItemType Type { get; private set; }
}