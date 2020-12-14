using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.28 </para>
    /// <para> 내    용 : 플레이 씬을 관리하는 스크립트 </para>
    /// </summary>
    public class MD_PlayManager : MD_Singlton<MD_PlayManager>
    {
        [Header("- Fade")]
        [SerializeField] private Image image_Fade;              // Fade 이미지

        [Header("- Menu")]
        [SerializeField] private GameObject[] menuArr;          // 메뉴들의 배열


        protected override void Awake()
        {
            base.Awake();
            Func_Init();        // 씬 초기화
        }

        // Start is called before the first frame update
        void Start()
        {
            MD_ProgramManager.Instance.Func_Fade(FADE.In, image_Fade);      // Fade In 효과
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.28 </para>
        /// <para> 내    용 : 플레이씬을 초기화 하는 메서드 </para>
        /// </summary>
        private new void Func_Init()
        {
            image_Fade.gameObject.SetActive(true);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.14 </para>
        /// <para> 내    용 : 모든 메뉴를 끄는 메서드 </para>
        /// </summary>
        private void Func_AllMenuDisable()
        {
            for (int i = 1; i < menuArr.Length; i++)
            {
                menuArr[i].SetActive(false);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.07.25 </para>
        /// <para> 내    용 : 캐릭터 버튼을 눌렀을 때 호출되는 버튼 메서드 </para>
        /// </summary>
        public void Button_Character()
        {
            Func_AllMenuDisable();          // 모든 메뉴를 닫는 기능
            menuArr[1].SetActive(true);
        }

        public void Button_BackToMain()
        {
            Func_AllMenuDisable();          // 모든 메뉴를 닫는 기능
            menuArr[0].SetActive(true);
        }

        public void Button_BackToCharacter()
        {
            Func_AllMenuDisable();          // 모든 메뉴를 닫는 기능
            menuArr[1].SetActive(true);
        }
    }
}