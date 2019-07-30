using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Admin
{
public static class Menu
    {
        [MenuItem("Test/Open/Admin", false, 9)]
        public static void OpenAdminWindow()
        {
            EditorWindow.GetWindow<AdminWindow>(false, "Admin", true).Show();
        }

        [MenuItem("Test/Debug/All", false, 9)]
        public static void ChangeHideFlag()
        {
            foreach (Transform obj in GameObject.FindObjectsOfType(typeof(Transform)))
            {
                Debug.Log($"obj:{obj.name}");
                if (obj.gameObject.hideFlags == HideFlags.None)
                {
                    obj.gameObject.hideFlags = HideFlags.HideInInspector;
                }
                else
                {
                    obj.gameObject.hideFlags = HideFlags.None;
                }
                EditorApplication.DirtyHierarchyWindowSorting();
            }
        }

        [MenuItem("Test/Shotcut/ActiveToggle _a")]
        public static void ActiveToggle()
        {
            foreach (GameObject obj in Selection.objects)
            {
                Undo.RecordObject(obj, "Undo ActiveToggle");
                obj.SetActive(!obj.activeSelf);
            }
        }

        /// <summary>
        /// ゲームオブジェクトのapply
        /// </summary>
        [MenuItem("Test/Shotcut/PrefabApply &a")]
        static void PrefabApply()
        {
            EditorApplication.ExecuteMenuItem("GameObject/Apply Changes To Prefab");
        }
    }

}
