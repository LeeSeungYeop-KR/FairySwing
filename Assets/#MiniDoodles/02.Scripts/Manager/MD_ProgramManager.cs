using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace MiniDoodles
{
    #region 열거형과 구조체

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.04 </para>
    /// <para> 내    용 : Fade 열거형</para>
    /// </summary>
    public enum FADE
    {
        In, Out
    }

    [System.Serializable]
    public struct MD_Volume
    {
        [Range(0f, 1f)]
        public float volume_BGM;

        [Range(0f, 1f)]
        public float volume_Effect;
    }

    #endregion

    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.04 </para>
    /// <para> 내    용 : 프로그램의 공통적으로 쓰이거나 관리해야하는것들을 모아놓은 스크립트 </para>
    /// </summary>
    public class MD_ProgramManager : MD_Singlton<MD_ProgramManager>
    {
        [Header("- Volume")]
        public MD_Volume soundVolume;

        [Header("- Fade Value")]
        public float fadeTime = 1.5f;

        protected override void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        #region Fade Function

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 이미지를 Fade처리하는 메서드 </para>
        /// </summary>
        public void Func_Fade(FADE _fade, Image _fadeImage)
        {
            if (_fade == FADE.In)
            {
                _fadeImage.DOFade(0f, fadeTime);
                _fadeImage.raycastTarget = false;
            }
            else       // Fade Out
            {
                _fadeImage.raycastTarget = true;
                _fadeImage.DOFade(1f, fadeTime);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 텍스트를 Fade처리하는 메서드 </para>
        /// </summary>
        public void Func_Fade(FADE _fade, Text _fadeText)
        {
            if (_fade == FADE.In)
            {
                _fadeText.DOFade(0f, fadeTime);
            }
            else
            {
                _fadeText.DOFade(1f, fadeTime);
            }
        }

        #endregion
    }
}