using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{

    public class MD_ScriptableManager : MD_Singlton<MD_ScriptableManager>
    {
        [Header("- 사용하는 스크립터블 배열")]
        public MD_BaseScriptableObject[] scriptableOBJArr;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public T Func_GetScriptable<T>() where T : MD_BaseScriptableObject
        {
            for (int i = 0; i < scriptableOBJArr.Length; i++)
            {
                if (scriptableOBJArr[i] as T)
                {
                    return (T)scriptableOBJArr[i];
                }
            }

            return null;
        }
    }
}