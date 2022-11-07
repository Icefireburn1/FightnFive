using System;
using UnityEngine;

/// <summary>
/// Used in conjunction with unit tests to stop Debug.errors from counting as errors
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
public class DebugLoggerEnablement : Attribute
{
    public DebugLoggerEnablement(bool enableLogger)
    {
        Debug.unityLogger.logEnabled = enableLogger;
    }
}
