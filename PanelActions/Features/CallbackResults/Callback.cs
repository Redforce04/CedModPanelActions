// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Callback.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/26/2023 12:16 PM
//    Created Date:     10/26/2023 12:16 PM
// -----------------------------------------

namespace PanelActions.CallbackResults;

internal class Callback
{
    internal Callback(string actionName)
    {
        ActionName = actionName;
        string actionSubstring = actionName.Split('-')[0];
        
    }
    public string ActionName { get; private set; }
    public ActionType ActionType { get; private set; }
}