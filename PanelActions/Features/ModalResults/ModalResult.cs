// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalResult.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 4:21 PM
//    Created Date:     10/19/2023 4:21 PM
// -----------------------------------------

using System.Collections.Generic;

namespace PanelActions.Features.ModalResults;

public sealed class ModalResult
{
    internal ModalResult()
    {
        Results = new Dictionary<string, ModalItemResult>();
    }
    public Dictionary<string, ModalItemResult> Results { get; private set; }
}