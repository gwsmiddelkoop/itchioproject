#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public static class ManagedReferenceUtility
{
    public static object AssignNewInstanceOfTypeToManagedReference(this SerializedProperty serializedProperty, Type type)
    {
        object instance = Activator.CreateInstance(type);
        serializedProperty.serializedObject.Update();
        serializedProperty.managedReferenceValue = instance;
        serializedProperty.serializedObject.ApplyModifiedProperties();
        return instance;
    }

    public static void SetManagedReferenceToNull(this SerializedProperty serializedProperty)
    {
        serializedProperty.serializedObject.Update();
        serializedProperty.managedReferenceValue = null;
        serializedProperty.serializedObject.ApplyModifiedProperties();
    }

    public static IEnumerable<Type> GetAppropriateTypesForAssigningToManagedReference(this SerializedProperty property, List<Func<Type, bool>> filters = null)
    {
        Type fieldType = property.GetManagedReferenceFieldType();
        return GetAppropriateTypesForAssigningToManagedReference(fieldType, filters);
    }

    public static IEnumerable<Type> GetAppropriateTypesForAssigningToManagedReference(Type fieldType, List<Func<Type, bool>> filters = null)
    {
        var appropriateTypes = new List<Type>();
        TypeCache.TypeCollection derivedTypes = TypeCache.GetTypesDerivedFrom(fieldType);
        foreach (Type type in derivedTypes)
        {
            if (type.IsSubclassOf(typeof(Object)))
            {
                continue;
            }
            if (type.IsAbstract)
            {
                continue;
            }
            if (type.ContainsGenericParameters)
            {
                continue;
            }
            if (type.IsClass && type.GetConstructor(Type.EmptyTypes) == null)
            {
                continue;
            }
            appropriateTypes.Add(type);
        }
        return appropriateTypes;
    }


    public static Type GetManagedReferenceFieldType(this SerializedProperty property)
    {
        Type realPropertyType = GetRealTypeFromTypename(property.managedReferenceFieldTypename);
        if (realPropertyType != null)
        {
            return realPropertyType;
        }

        Debug.LogError($"Can not get field type of managed reference : {property.managedReferenceFieldTypename}");
        return null;
    }

    public static Type GetRealTypeFromTypename(string stringType)
    {
        (string assemblyName, string className) names = GetSplitNamesFromTypename(stringType);
        Type realType = Type.GetType($"{names.className}, {names.assemblyName}");
        return realType;
    }

    public static (string assemblyName, string className) GetSplitNamesFromTypename(string typename)
    {
        if (string.IsNullOrEmpty(typename))
        {
            return ("", "");
        }
        string[] typeSplitString = typename.Split(char.Parse(" "));
        string typeClassName = typeSplitString[1];
        string typeAssemblyName = typeSplitString[0];
        return (typeAssemblyName, typeClassName);
    }

    public static Type GetManagedReferenceInstanceType(this SerializedProperty property)
    {
        (string assemblyName, string className) splitNames = GetSplitNamesFromTypename(property.managedReferenceFieldTypename);
        string[] namespaceSplitString = splitNames.className.Split(char.Parse("."));
        string namespaceString = string.Empty;
        for (int i = 0; i < namespaceSplitString.Length - 1; i++)
        {
            if (i > 0)
            {
                namespaceString += ".";
            }
            namespaceString += namespaceSplitString[i];
        }
        string typeWithoutNamespaceString = property.type.Split(char.Parse("<")).Last().Split(char.Parse(">"))[0];
        if (namespaceString != string.Empty)
        {
            namespaceString += ".";
        }
        Type type = Type.GetType($"{namespaceString + typeWithoutNamespaceString}, {splitNames.assemblyName}");
        return type;
    }
}
#endif
