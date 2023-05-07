using Data;
using Services.Quest;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class FillCubeData : EditorWindow
    {
        [MenuItem("Tools/Fill cube datas")]
        public static void Fill()
        {
            var questService = FindObjectOfType<QuestsService>();

            CubeActor[] cubes = Selection.activeGameObject.GetComponentsInChildren<CubeActor>();

            for (int i = 0; i < cubes.Length; ++i)
            {
                if(i + 1 <= cubes.Length) 
                {
                    questService.FillQuestData(cubes[i], cubes[i + 1]);
                    i++;
                }
            }
        }
    }
}