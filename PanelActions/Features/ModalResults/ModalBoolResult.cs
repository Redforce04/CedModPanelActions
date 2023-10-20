// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalBoolResult.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 4:25 PM
//    Created Date:     10/19/2023 4:25 PM
// -----------------------------------------

namespace PanelActions.Features.ModalResults;

public sealed class ModalBoolResult : ModalItemResult
{
    public override ModalItemType Type => ModalItemType.Bool;
    internal ModalBoolResult(string name, ModalItemType type) : base(name)
    {
        
    }
    public bool Value { get; private set; }
}