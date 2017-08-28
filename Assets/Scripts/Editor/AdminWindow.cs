using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;



[Serializable]
public class Item
{
    public string Name { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
}

public class AdminWindow : EditorWindow
{
    List<Item> itemList = new List<Item>();
    ReorderableList reorderableList;
    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        reorderableList = new ReorderableList(itemList, typeof(List<Item>));
        // reorderableList.list = _DatabaseObject.itemList;
        // reorderableList.onAddCallback += (itemList) =>
        // {
        //     itemList.serializedProperty.arraySize++;
        //     // itemList.list.Add(new ItemDatabaseObject.Item());
        //     itemList.index = itemList.serializedProperty.arraySize - 1;
        // };
        reorderableList.drawElementCallback += (rect, index, isActive, isFocused) =>
        {
            var item = reorderableList.list[index] as Item;
            Debug.Log($"count:{reorderableList.list.Count}");
            // var item = reorderableList.serializedProperty.GetArrayElementAtIndex(index);
            // EditorGUI.PropertyField(rect, item, GUIContent.none);
            // var name = item.FindPropertyRelative("name");
            // Debug.Log($"item class:{name.ToString()}");
            rect.width = 100f;
            item.Name = EditorGUI.TextField(rect, item.Name);
            rect.x += rect.width;
            item.Value = EditorGUI.TextField(rect, item.Value);
        };
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        reorderableList.DoLayoutList();
    }
}
