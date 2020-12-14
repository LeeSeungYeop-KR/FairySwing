using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.28 </para>
    /// <para> 내    용 : 로딩 씬을 관리하는 스크립트 </para>
    /// </summary>
    public class MD_Loading : MonoBehaviour
    {
        [Header("- UI")]
        [SerializeField] private Text text_Loading;             // 로딩 텍스트
        [SerializeField] private float changeTime = 0.7f;       // 텍스트가 변하는 시간

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Co_LoadingText());
            Func_ChangeScene();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 씬매니져에 저장되어 있는 변수로 어디로 씬을 옮겨야 할지 결정하는 메서드 </para>
        /// </summary>
        private void Func_ChangeScene()
        {
            switch (MD_SceneManager.Instance.sceneKind)
            {
                case SCENE_KIND.Intro:
                    MD_SceneManager.Instance.Func_SceneChange("#00.Intro");
                    break;

                case SCENE_KIND.Main:
                    MD_SceneManager.Instance.Func_SceneChange("#01.Main");
                    break;

                default:
                    Debug.Log("설정되지 않은 씬");
                    break;
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 로딩 텍스트를 바꿔주는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_LoadingText()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(changeTime);
                text_Loading.text = "Loading.";
                yield return new WaitForSecondsRealtime(changeTime);
                text_Loading.text = "Loading..";
                yield return new WaitForSecondsRealtime(changeTime);
                text_Loading.text = "Loading...";
                yield return new WaitForSecondsRealtime(changeTime);
                text_Loading.text = "Loading";
            }
        }
    }
}