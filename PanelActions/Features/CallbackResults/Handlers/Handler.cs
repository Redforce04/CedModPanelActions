﻿// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Handler.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/26/2023 12:15 PM
//    Created Date:     10/26/2023 12:15 PM
// -----------------------------------------

namespace PanelActions.CallbackResults.Handlers;

internal abstract class Handler
{
    
    internal abstract void HandleCallback(Callback callback);
}