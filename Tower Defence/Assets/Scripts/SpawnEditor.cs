using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Spawn))]
public class SpawnEditor : Editor
{
    private SerializedProperty monsterPrefabsProp;
    private SerializedProperty monsterCountsProp;
    private SerializedProperty monsterOrderProp;

    private void OnEnable()
    {
        monsterPrefabsProp = serializedObject.FindProperty("monsterPrefabs");
        monsterCountsProp = serializedObject.FindProperty("monsterCounts");
        monsterOrderProp = serializedObject.FindProperty("monsterOrder");

        // Update monsterOrder array when monsterPrefabs is modified
        monsterPrefabsProp.serializedObject.Update();
        if (monsterPrefabsProp.arraySize > 0)
        {
            monsterOrderProp.arraySize = monsterPrefabsProp.arraySize;
            monsterOrderProp.GetArrayElementAtIndex(0).intValue = 0;

            for (int i = 1; i < monsterOrderProp.arraySize; i++)
            {
                monsterOrderProp.GetArrayElementAtIndex(i).intValue = monsterOrderProp.GetArrayElementAtIndex(i - 1).intValue + 1;
            }
        }
        monsterPrefabsProp.serializedObject.ApplyModifiedProperties();
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(monsterPrefabsProp, true);

        if (monsterPrefabsProp.arraySize != monsterCountsProp.arraySize)
        {
            monsterCountsProp.arraySize = monsterPrefabsProp.arraySize;
            monsterOrderProp.arraySize = monsterPrefabsProp.arraySize;

            // Increment monsterOrder values when a new element is added to monsterPrefabs
            if (monsterOrderProp.arraySize > 1)
            {
                monsterOrderProp.GetArrayElementAtIndex(monsterOrderProp.arraySize - 1).intValue = monsterOrderProp.GetArrayElementAtIndex(monsterOrderProp.arraySize - 2).intValue + 1;
            }
        }

        for (int i = 0; i < monsterPrefabsProp.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(monsterPrefabsProp.GetArrayElementAtIndex(i).objectReferenceValue != null ? monsterPrefabsProp.GetArrayElementAtIndex(i).objectReferenceValue.name : "None", GUILayout.Width(200));

            EditorGUILayout.PropertyField(monsterCountsProp.GetArrayElementAtIndex(i), GUIContent.none, GUILayout.Width(50));
            EditorGUILayout.PropertyField(monsterOrderProp.GetArrayElementAtIndex(i), GUIContent.none, GUILayout.Width(50));

            EditorGUILayout.EndHorizontal();
        }

        serializedObject.ApplyModifiedProperties();
    }
}
