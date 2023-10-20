// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalStringResult.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 4:26 PM
//    Created Date:     10/19/2023 4:26 PM
// -----------------------------------------

namespace PanelActions.Features.ModalResults;

public sealed class ModalStringResult : ModalItemResult
{
    public override ModalItemType Type => ModalItemType.String;

    internal ModalStringResult(string name, ModalItemType type) : base(name)
    {
    }
    public string Value { get; private set; }
    
}