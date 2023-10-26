// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         PanelActions
//    Project:          PanelActions
//    FileName:         Logging.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/25/2023 11:56 AM
//    Created Date:     10/25/2023 11:56 AM
// -----------------------------------------

using System;

namespace PanelActions;

public static class Logging
{
    public static void Log(string message, LogLevel logLevel = LogLevel.Debug)
    {
        // Console.WriteLine($"[{logLevel}] {message}");
        OnLog.Invoke(message, logLevel);
    }
    public static event Action<string, LogLevel> OnLog;
}

public enum LogLevel
{
    Debug,
    Warn,
    Error,
    Info,
}