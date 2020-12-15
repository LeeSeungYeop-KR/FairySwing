using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.12.11 </para>
    /// <para> 내    용 : 장비 메뉴 클래스 </para>
    /// </summary>
    public class MD_Menu_Equipment : MonoBehaviour
    {
        [Header("- 캐릭터 이미지")]
        [SerializeField] private Image image_Character;

        [Header("- 캐릭터 이름")]
        [SerializeField] private Text text_CharacterName;

        [Header("- 캐릭터의 별 Pool")]
        [SerializeField] private Transform star_Parent;

        [Header("- 장비창의 캐릭터 데이터")]
        [Space(20)]
        [SerializeField] private MD_CharacterData dataCharacter;

        [Header("- 장비창의 이전버튼 배열")]
        [SerializeField] private GameObject[] button_BackArr;

        private void OnEnable()
        {
            Func_Init();
            Func_SetCharacter();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.15 </para>
        /// <para> 내    용 : 장비 메뉴를 초기화하는 기능 </para>
        /// </summary>
        private void Func_Init()
        {
            for (int i = 0; i < button_BackArr.Length; i++)
            {
                button_BackArr[i].SetActive(false);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.15 </para>
        /// <para> 내    용 : 장비 메뉴의 캐릭터를 설정하는 기능 </para>
        /// </summary>
        private void Func_SetCharacter()
        {
            dataCharacter = MD_PlayManager.Instance.characterData;

            if (dataCharacter.data_ID == -1)     // 캐릭터 정해지지 않음
            {
                dataCharacter = MD_XML.Instance.Func_GetCharacterCard()[0];
                button_BackArr[0].SetActive(true);
            }
            else
            {
                button_BackArr[1].SetActive(true);
            }

            text_CharacterName.text = dataCharacter.data_name;
            image_Character.sprite = MD_ScriptableManager.Instance.Func_GetScriptable<MD_CharacterCard_Setting>()
                .sprite_CharacterArr[dataCharacter.data_ID];
            Func_SetCharacterStar(dataCharacter.data_StarNum);
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.15 </para>
        /// <para> 내    용 : 장비 메뉴의 캐릭터의 별 개수를 설정하는 기능 </para>
        /// </summary>
        private void Func_SetCharacterStar(int _starNum)
        {
            for (int i = 0; i < star_Parent.childCount; i++)
            {
                star_Parent.GetChild(i).gameObject.SetActive(false);        // 모든 별 끄기
            }

            for (int i = 0; i < _starNum; i++)
            {
                star_Parent.GetChild(i).gameObject.SetActive(true);         // 별 갯수만큼 켜기
            }
        }
    }
}