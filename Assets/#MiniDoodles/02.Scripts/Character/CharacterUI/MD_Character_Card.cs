using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.11.28</para>
    /// <para>내    용 : 캐릭터 카드의 데이터 구조체 </para>
    /// </summary>
    [System.Serializable]
    public struct MD_CharacterData
    {
        /// <summary>
        /// 캐릭터 아이디
        /// </summary>
        public int data_ID;

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
    /// <para>내    용 : 캐릭터 카드에 대한 클래스</para>
    /// </summary>
    public class MD_Character_Card : MonoBehaviour
    {
        [Header("- 캐릭터 관리")]
        public MD_Menu_Character characterController;

        [Header("- 캐릭터 번호")]
        [SerializeField] private int cardNum;

        [Space(20)]
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
        
        private void Start()
        {
            Func_InitCard();
        }

        #region 1. 카드의 설정 메서드

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.28</para>
        /// <para>내    용 : 캐릭터 카드의 데이터를 설정하는 메서드</para>
        /// </summary>
        public void Func_SetCardData(MD_CharacterData _data, int _cardNum)
        {
            cardNum = _cardNum;     // 이 카드의 번호
            data = _data;           // 카드의 데이터
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.28</para>
        /// <para>내    용 : 캐릭터 카드를 초기 설정하는 메서드</para>
        /// </summary>
        private void Func_InitCard()
        {
            Func_SetCharacterImage();   // 캐릭터의 이미지 설정
            Func_SetName();             // 캐릭터의 이름 설정
            Func_SetLevel();            // 캐릭터의 레벨 설정
            Func_SetStar();             // 별 개수만큼 별 만들기
            Func_SetButton();           // 버튼 이벤트 추가
        }

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.28</para>
        /// <para>내    용 : 카드의 이미지를 설정하는 메서드</para>
        /// </summary>
        private void Func_SetCharacterImage()
        {
            if (data.data_ID != -1)
            {
                image_Character.sprite = MD_ScriptableManager.Instance.Func_GetScriptable<MD_CharacterCard_Setting>().sprite_CharacterArr[data.data_ID];
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

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.12.15</para>
        /// <para>내    용 : 카드의 버튼을 설정하는 메서드</para>
        /// </summary>
        private void Func_SetButton()
        {
            Button _button = GetComponent<Button>();

            if (_button != null)
            {
                _button.onClick.AddListener(Button_ClickCharacter_Card);
            }
        }

        #endregion

        #region Button

        /// <summary>
        /// <para>작 성 자 : 이승엽</para>
        /// <para>작 성 일 : 2020.11.17</para>
        /// <para>내    용 : 일러스트를 클릭했을 때 장비창으로 이동하는 메서드</para>
        /// </summary>
        public void Button_ClickCharacter_Card()
        {
            Debug.Log("클릭 캐릭터 일러스트");
            characterController?.Func_PopEquipment(cardNum, data);
        }

        #endregion
    }
}