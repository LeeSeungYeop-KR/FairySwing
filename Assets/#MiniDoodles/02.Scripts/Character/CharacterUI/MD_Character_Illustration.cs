using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.11.28</para>
    /// <para>내    용 : 캐릭터 일러스트의 데이터 구조체 </para>
    /// </summary>
    [System.Serializable]
    public struct MD_CharacterData
    {
        /// <summary>
        /// 캐릭터 스프라이트
        /// </summary>
        public Sprite data_Sprite;

        /// <summary>
        /// 캐릭터 이름
        /// </summary>
        public string data_name;

        /// <summary>
        /// 캐릭터 레벨
        /// </summary>
        public int data_level;

        /// <summary>
        /// 캐릭터 별 개수
        /// </summary>
        public int data_StarNum;
    }

    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.11.17</para>
    /// <para>내    용 : 캐릭터 일러스트에 대한 클래스</para>
    /// </summary>
    public class MD_Character_Illustration : MonoBehaviour
    {
        [Header("- 캐릭터 관리")]
        public MD_Menu_Character characterController;

        [Header("- 캐릭터의 이미지")]
        [SerializeField] private Image image_Character;

        [Header("- 캐릭터의 이름")]
        [SerializeField] private Text text_Name;

        [Header("- 캐릭터의 레벨 텍스트")]
        [SerializeField] private Text text_Level;

        [Header("- 캐릭터의 별을 모아놓은 객체")]
        [SerializeField] private Transform star_parent;

        [Header("- 캐릭터 카드의 데이터")]
        public MD_CharacterData data;

        public MD_Character_Illustration(MD_CharacterData _data)
        {
            data = _data;
        }

        private void Start()
        {
            Func_InitCard();
        }

        #region 1. 카드의 설정 메서드

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.28</para>
        /// <para>내    용 : 캐릭터 카드를 설정하는 메서드</para>
        /// </summary>
        private void Func_InitCard()
        {
            Func_SetCharacterImage();   // 캐릭터의 이미지 설정
            Func_SetName();             // 캐릭터의 이름 설정
            Func_SetLevel();            // 캐릭터의 레벨 설정
            Func_SetStar();             // 별 개수만큼 별 만들기
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.28</para>
        /// <para>내    용 : 카드의 이미지를 설정하는 메서드</para>
        /// </summary>
        private void Func_SetCharacterImage()
        {
            if (data.data_Sprite != null)
            {
                image_Character.sprite = data.data_Sprite;
            }
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.28</para>
        /// <para>내    용 : 카드의 이름을 설정하는 메서드</para>
        /// </summary>
        private void Func_SetName()
        {
            if (data.data_name != string.Empty)
            {
                text_Name.text = data.data_name;
            }
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.28</para>
        /// <para>내    용 : 카드의 레벨을 설정하는 메서드</para>
        /// </summary>
        private void Func_SetLevel()
        {
            text_Level.text = "Lv." + data.data_level;
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.28</para>
        /// <para>내    용 : 카드의 별 개수를 설정하는 메서드</para>
        /// </summary>
        private void Func_SetStar()
        {
            GameObject _star = MD_ScriptableManager.Instance.Func_GetScriptable<MD_CharacterCard_Setting>().prefab_Star;

            for (int i = 0; i < data.data_StarNum; i++)
            {
                Instantiate(_star, star_parent);
            }
        }

        #endregion

        #region Button

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.17</para>
        /// <para>내    용 : 일러스트를 클릭했을 때 장비창으로 이동하는 메서드</para>
        /// </summary>
        public void Button_ClickCharacter_Illustration()
        {
            Debug.Log("클릭 캐릭터 일러스트");
        }

        #endregion
    }
}