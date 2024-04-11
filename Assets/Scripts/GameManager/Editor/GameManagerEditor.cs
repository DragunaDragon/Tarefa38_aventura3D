
using UnityEditor;
using System.Linq;


[CustomEditor(typeof(GameManager))]

public class GameManagerEditor : Editor
{
    public bool showFoldout;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameManager fsm = (GameManager)target;

        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("State machine");

        if (fsm.stateMachine == null) return;

        if (fsm.stateMachine.CurrentState != null)
        {
            EditorGUILayout.LabelField("Current State:", fsm.stateMachine.CurrentState.ToString());
        }


        showFoldout = EditorGUILayout.Foldout(showFoldout, "Avaiable States");


        if (showFoldout)
        {

            if (fsm.stateMachine.dicionaryState != null)
            {
                var keys = fsm.stateMachine.dicionaryState.Keys.ToArray();
                var vals = fsm.stateMachine.dicionaryState.Values.ToArray();

                for (int i = 0; i < keys.Length; i++)
                {
                    EditorGUILayout.LabelField(string.Format("{0} :: {1}", keys[i], vals[i]));
                }


            }

        }


    }


}