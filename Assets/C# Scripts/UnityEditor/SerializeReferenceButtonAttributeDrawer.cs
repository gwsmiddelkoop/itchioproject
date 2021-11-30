#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(SerializeReferenceButtonAttribute))]
class SerializeReferenceButtonAttributeDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string labelName = "Null";
        Type instanceType = property.GetManagedReferenceInstanceType();
        if (instanceType != null)
        {
            labelName = instanceType.ToString();
        }
        EditorGUI.PropertyField(position, property, label, true);

        Color originalColor = GUI.color;

        GUI.color = Color.yellow;
        if (property.isExpanded)
        {
            EditorGUI.indentLevel++;
            EditorGUI.LabelField(new Rect(position.x, position.yMax - 20f, position.width, 20f), "Type");
            EditorGUI.indentLevel--;
        }
        GUI.color = instanceType != null ? Color.green : Color.red;
        position = new Rect(position.x + EditorGUIUtility.labelWidth + 2, position.yMax - 20f, position.width - EditorGUIUtility.labelWidth - 2, 20f);
        if (!EditorGUI.DropdownButton(position, new GUIContent(labelName), FocusType.Passive))
        {
            GUI.color = originalColor;
            return;
        }
        GUI.color = originalColor;
        List<Type> options = (List<Type>)property.GetAppropriateTypesForAssigningToManagedReference(null);

        void HandleItemClicked(object parameter)
        {
            Type type = (Type)parameter;
            if (type != instanceType)
            {
                property.AssignNewInstanceOfTypeToManagedReference(type);
            }
        }

        GenericMenu menu = new GenericMenu();
        for (int i = 0; i < options.Count; i++)
        {
            bool on = instanceType != null && options[i] == instanceType;
            menu.AddItem(new GUIContent(options[i].ToString()), on, HandleItemClicked, options[i]);
        }
        menu.DropDown(position);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property.isExpanded)
        {
            return EditorGUI.GetPropertyHeight(property) + 20f;
        }
        return EditorGUI.GetPropertyHeight(property);
    }
}
#endif