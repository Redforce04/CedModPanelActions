// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalEnumResult.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 4:25 PM
//    Created Date:     10/19/2023 4:25 PM
// -----------------------------------------

using System;

namespace PanelActions.Features.ModalResults;

public sealed class ModalEnumResult : ModalItemResult
{
    public override ModalItemType Type => ModalItemType.Enum;
    internal ModalEnumResult(string name, ModalItemType type) : base(name)
    {
        
    }
    public Enum Value { get; private set; }

}