// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         ModalString.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/19/2023 11:57 AM
//    Created Date:     10/19/2023 11:57 AM
// -----------------------------------------

namespace PanelActions;

public sealed class ModalString : ModalItem
{
    public override ModalItemType ModalItemType { get; protected set; } = ModalItemType.String;
    public ModalString(string name, string title, string description = "", 
        string placeholder = "", 
        string regexFilter = "")
    {
        Name = $"{nameof(ModalString)}-{name}";
        Title = title;
        Description = description;
        Placeholder = placeholder;
        RegexFilter = regexFilter;
    }
    public override string Name { get; protected set; }
    public override string Title { get; protected set; }
    public override string Description { get; protected set; }
    public string Placeholder { get; protected set; } = "";
    public string RegexFilter { get; protected set; } = "";
}