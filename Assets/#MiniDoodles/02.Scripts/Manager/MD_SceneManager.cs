﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2019.11.19</para>
    /// <para>내    용 : 씬의 종류</para>
    /// </summary>
    public enum SCENE_KIND
    {
        Intro, Main
    }

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2019.11.19</para>
    /// <para>내    용 : 씬을 바꿔주는 스크립트</para>
    /// </summary>
    public class MD_SceneManager : MD_Singlton<MD_SceneManager>
    {
        public SCENE_KIND sceneKind;    // 가야 할 씬의 종류

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2019.11.19</para>
        /// <para>내    용 : Fade처리 없이 씬을 이동</para>
        /// </summary>
        public void Func_SceneChange(string _sceneName)
        {
            SceneManager.LoadSceneAsync(_sceneName);
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2019.11.19</para>
        /// <para>내    용 : Fade처리후 씬을 이동</para>
        /// </summary>
        public void Func_SceneLoading(SCENE_KIND _sceneKind)
        {
            StartCoroutine(Co_SceneLoading(_sceneKind));
        }
        IEnumerator Co_SceneLoading(SCENE_KIND _sceneKind)
        {
            sceneKind = _sceneKind;
            //MD_ProgramManager.Instance.Func_Fade(FADE.Out);
            //yield return new WaitForSecondsRealtime(MD_PlayerController.Instance.fadeTime);
            yield return null;

            SceneManager.LoadSceneAsync("#00.Loading");
        }


    }
}
