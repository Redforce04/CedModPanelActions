// <copyright file="Log.cs" company="Redforce04#4091">
// Copyright (c) Redforce04. All rights reserved.
// </copyright>
// -----------------------------------------
//    Solution:         AutoEvent
//    Project:          AutoEvent
//    FileName:         AbstractTypeExtensions.cs
//    Author:           Redforce04#4091
//    Revision Date:    10/17/2023 1:30 AM
//    Created Date:     10/17/2023 1:30 AM
// -----------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using PanelActions.Attributes;
using PanelActions.Internal;

namespace PanelActions;

public static class AbstractedTypeExtensions
{

    /// <summary>
    /// Registers an action.
    /// </summary>
    /// <param name="action">The <see cref="Action"/> to register.</param>
    public static void RegisterAction(this Action action)
    {
        ActionManager.RegisterAction(action);
    }

    /// <summary>
    /// UnRegisters an action.
    /// </summary>
    /// <param name="action">The <see cref="Action"/> to unregister.</param>
    public static void UnRegisterAction(this Action action)
    {
        ActionManager.UnRegisterAction(action);
    }
    
    /// <summary>
    /// Every instance of the type found in any loaded assembly will be instantiated and returned into list form.
    /// </summary>
    /// <param name="type">The type to instantiate instances of.</param>
    /// <returns>A list of all found instances of <see cref="T"/>.</returns>
    public static List<T> InstantiateAllInstancesOfType<T>()
        where T : class
    {
        Type type = typeof(T);
        List<T> instanceList = new List<T>();

        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                foreach (Type typeInstance in HarmonyLib.AccessTools.GetTypesFromAssembly(assembly))
                {
                    if (typeInstance.IsAbstract || typeInstance.IsInterface)
                        continue;

                    if (!typeInstance.IsSubclassOf(type))
                        continue;

                    try
                    {
                        if (Activator.CreateInstance(typeInstance) is not T instance)
                            continue;

                        instanceList.Add(instance);
                    }
                    catch
                    {
                        //
                    }
                }
            }
            catch
            {
                //
            }
        }

        return instanceList;
    }

    public static List<AttributeResult> FindAllInstancesOfAttribute<T>() where T : ActionItemAttribute
    {
        List<AttributeResult> list = new List<AttributeResult>();
        int count = 0;
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                /*if (!Attribute.IsDefined(assembly, typeof(T)))
                {
                    Logging.Log($"{assembly.GetName().Name} has no attributes of {typeof(T).Name}");
                    continue;
                }*/

                foreach (Type type in assembly.GetTypes())
                {
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        List<ParameterAttributeResult> parms = new List<ParameterAttributeResult>();
                        foreach (ParameterInfo parameter in method.GetParameters())
                        {
                            var parameterAttribute = parameter.GetCustomAttribute<T>();
                            if (parameterAttribute is null || parameterAttribute is not T)
                            {
                                continue;
                            }
                            var parameterResult = new ParameterAttributeResult(type, parameterAttribute, parameter);
                            parms.Add(parameterResult);
                        }
                        
                        var attribute = method.GetCustomAttribute<T>();
                        MethodAttributeResult? methodResult = null;
                        if (attribute is null)
                        {
                            goto getParams;
                        }

                        methodResult = new MethodAttributeResult(type, attribute, method, parms);
                        list.Add(methodResult);
                        if (list.Count != count)
                        {
                            count = list.Count;
                            // Logging.Log("");
                        }
                        getParams:
                        if (methodResult is not null || methodResult is not T)
                        {
                            ParameterAttributeResult[] array = parms.ToArray();
                            for (int i = 0; i < array.Length; i ++)
                            {
                                array[i].SetMethodAttributes(methodResult);
                            }

                            parms = array.ToList();
                        }
                        list.AddRange(parms);
                        if (list.Count != count)
                        {
                            count = list.Count;
                            // Logging.Log("");
                        }
                    }

                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        var attribute = property.GetCustomAttribute<T>();
                        if (attribute is null || attribute is not T)
                        {
                            continue;
                        }
                        
                        var methodResult = new PropertyAttributeResult(type, attribute, property);
                        list.Add(methodResult);
                        if (list.Count != count)
                        {
                            count = list.Count;
                            // Logging.Log("");
                        }
                    }

                    
                }
            }
            catch (Exception e)
            {
                Logging.Log($"Caught an exception.\n {e}");
            }
        }

        return list;
    }

    public abstract class AttributeResult
    {
        public AttributeResult(Type type, Attribute attribute)
        {
            Assembly = type.Assembly;
            Type = type;
            Attribute = attribute;
        }
        public Attribute Attribute { get; private set; }
        public Assembly Assembly { get; private set; }
        public Type Type { get; private set; }
        public string ItemName { get; protected set; }
    }

    public sealed class MethodAttributeResult : AttributeResult
    {
        public MethodAttributeResult(Type type, Attribute attribute, MethodInfo methodInfo, List<ParameterAttributeResult>? parameters = null) : base(type, attribute)
        {
            MethodInfo = methodInfo;
            ParameterAttributeResults = new ReadOnlyCollection<ParameterAttributeResult>(parameters ?? new List<ParameterAttributeResult>());
            ItemName = methodInfo.Name;
        }
        public MethodInfo MethodInfo { get; private set; }
        public ReadOnlyCollection<ParameterAttributeResult> ParameterAttributeResults { get; private set; }
    }
    public sealed class PropertyAttributeResult : AttributeResult
    {
        public PropertyAttributeResult(Type type, Attribute attribute, PropertyInfo propertyInfo) : base(type, attribute)
        {
            PropertyInfo = propertyInfo;
            ItemName = propertyInfo.Name;
        }
        public PropertyInfo PropertyInfo { get; private set; }
    }

    public sealed class ParameterAttributeResult : AttributeResult
    {
        public ParameterAttributeResult(Type type, Attribute attribute, ParameterInfo parameterInfo, MethodAttributeResult? methodInfo = null) : base(type, attribute)
        {
            ParameterInfo = parameterInfo;
            MethodAttributeResult = methodInfo;
            ItemName = parameterInfo.Name;
        }
        public ParameterInfo ParameterInfo { get; private set; }
        public MethodAttributeResult? MethodAttributeResult { get; private set; }

        internal void SetMethodAttributes(MethodAttributeResult attributeResult)
        {
            MethodAttributeResult = attributeResult;
        }
    }
}