// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ItemAttribute.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 3:55 PM
//    Created Date:     10/19/2023 3:55 PM
// -----------------------------------------

using System;

namespace PanelActions;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class ActionItemAttribute : Attribute
{
    
}