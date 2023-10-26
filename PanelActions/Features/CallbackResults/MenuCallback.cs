// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         MenuSelctionCallback.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/26/2023 12:20 PM
//    Created Date:     10/26/2023 12:20 PM
// -----------------------------------------

namespace PanelActions.CallbackResults;

internal sealed class MenuCallback : Callback
{
    internal MenuCallback(string actionName, string menuSelectionValue) : base(actionName)
    {
        
    }
    public string MenuSelectionName { get; set; }
    // public MenuSelection Selection;
}