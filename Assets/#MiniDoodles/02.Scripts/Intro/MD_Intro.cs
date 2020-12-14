using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.03 </para>
    /// <para> 내    용 : 인트로 씬에 쓰이는 스크립트 </para>
    /// </summary>
    public class MD_Intro : MonoBehaviour
    {
        [Header("- Setting")]
        [SerializeField] private GameObject button_keepPlay;    // 이어하기 버튼 오브젝트
        [SerializeField] private Text text_Version;             // 버전 텍스트


        [Header("- Intro Loading Value")]
        [SerializeField] private Text text_Loading;         // 로딩 텍스트
        private IEnumerator coSetTextLoading;               // 로딩 텍스트 효과 코루틴 변수
        private bool isLoadEnd = false;                     // 로딩이 끝났는지 체크

        [Header("- Fade Value")]
        [SerializeField] private Image image_Fade;          // Fade하는 이미지
        [SerializeField] private Text text_Logo;            // 로고 텍스트

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(Func_IntroLoadingStart());       // 인트로 로딩화면 시작
            Func_InitIntro();
        }

        #region 인트로 메서드

        private void Func_InitIntro()
        {
#if UNITY_EDITOR
            // 버전 텍스트 수정
            text_Version.text = "ver. " + UnityEditor.PlayerSettings.bundleVersion;
#else
            text_Version.text = "ver. " + Application.version;
#endif

            // 세이브 파일이 있다면
            if (MD_XML.Instance.isExist)
            {
                button_keepPlay.SetActive(true); // 이어하기 버튼 활성화
            }

        }

        #endregion

        #region 버튼 메서드

        public void Func_NewStart()
        {
            MD_SceneManager.Instance.Func_SceneLoading(SCENE_KIND.Main);
        }

        #endregion

        #region 인트로 로딩 메서드

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 인트로에서 첫 로딩화면을 시작하는 메서드 </para>
        /// </summary>
        private IEnumerator Func_IntroLoadingStart()
        {
            MD_ProgramManager.Instance.Func_Fade(FADE.Out, text_Logo);      // 로고 보이기
            Func_SetTextLoading();                                          // 로딩 텍스트 효과 시작
            yield return new WaitForSecondsRealtime(MD_ProgramManager.Instance.fadeTime + 1.5f);

            MD_ProgramManager.Instance.Func_Fade(FADE.In, text_Logo);       // 로고 안보이기
            yield return new WaitForSecondsRealtime(MD_ProgramManager.Instance.fadeTime);

            MD_ProgramManager.Instance.Func_Fade(FADE.In, image_Fade);      // Fade이미지 안보이기
            Func_StopTextLoading();                                         // 로딩 텍스트 효과 끄기
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 로딩화면에서 로딩 텍스트 효과를 주는 메서드 </para>
        /// </summary>
        private void Func_SetTextLoading()
        {
            text_Loading.gameObject.SetActive(true);
            isLoadEnd = false;
            coSetTextLoading = Co_SetTextLoading();
            StartCoroutine(coSetTextLoading);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 로딩화면에서 로딩 텍스트 효과를 끄는 메서드 </para>
        /// </summary>
        private void Func_StopTextLoading()
        {
            isLoadEnd = true;
            StopCoroutine(coSetTextLoading);
            text_Loading.gameObject.SetActive(false);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 로딩화면에서 로딩 텍스트 효과를 주는 코루틴 </para>
        /// </summary>
        private IEnumerator Co_SetTextLoading()
        {
            while (!isLoadEnd)
            {
                yield return new WaitForSecondsRealtime(0.8f);
                text_Loading.text = "Loading.";
                yield return new WaitForSecondsRealtime(0.8f);
                text_Loading.text = "Loading..";
                yield return new WaitForSecondsRealtime(0.8f);
                text_Loading.text = "Loading...";
                yield return new WaitForSecondsRealtime(0.8f);
                text_Loading.text = "Loading";
            }
        }

        #endregion


    }
}
