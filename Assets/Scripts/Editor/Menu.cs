using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class Menu
{
    [MenuItem("Test/Open/Admin", false, 9)]
    public static void OpenAdminWindow()
    {
        EditorWindow.GetWindow<AdminWindow>(false, "Admin", true).Show();
    }
}
