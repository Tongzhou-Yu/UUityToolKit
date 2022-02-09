using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;


//
//���ҽڵ㼰�����ӽڵ���,�Ƿ���ָ���Ľű����
//
public class MonoFinder : EditorWindow
{
    Transform root = null;
    MonoScript scriptObj = null;
    int loopCount = 0;

    List<Transform> results = new List<Transform>();

    [MenuItem("EasyToolKit/MonoFinder")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(MonoFinder));
    }

    void OnGUI()
    {
        GUILayout.Label("�ڵ�:");
        root = (Transform)EditorGUILayout.ObjectField(root, typeof(Transform), true);
        GUILayout.Label("�ű�����:");
        scriptObj = (MonoScript)EditorGUILayout.ObjectField(scriptObj, typeof(MonoScript), true);
        if (GUILayout.Button("Find"))
        {
            results.Clear();
            loopCount = 0;
            Debug.Log("��ʼ����.");
            FindScript(root);
        }
        if (results.Count > 0)
        {
            foreach (Transform t in results)
            {
                EditorGUILayout.ObjectField(t, typeof(Transform), false);
            }
        }
        else
        {
            GUILayout.Label("�޽��");
        }
    }

    void FindScript(Transform root)
    {
        if (root != null && scriptObj != null)
        {
            loopCount++;
            Debug.Log(".." + loopCount + ":" + root.gameObject.name);
            if (root.GetComponent(scriptObj.GetClass()) != null)
            {
                results.Add(root);
            }
            foreach (Transform t in root)
            {
                FindScript(t);
            }
        }
    }
}