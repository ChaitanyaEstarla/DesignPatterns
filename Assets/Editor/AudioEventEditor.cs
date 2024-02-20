using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioEvent), true)]
public class AudioEventEditor : Editor
{
    [SerializeField] private AudioSource _previewer;

    public void OnEnable()
    {
        _previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio Preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        DestroyImmediate(_previewer.gameObject);
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
        if(GUILayout.Button("Preview"))
        {
            ((AudioEvent)target).Play(_previewer);
        }
        EditorGUI.EndDisabledGroup();
    }
}