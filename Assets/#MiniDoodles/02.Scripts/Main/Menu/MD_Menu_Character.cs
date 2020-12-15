using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.11.18 </para>
    /// <para> 내    용 : 캐릭터 메뉴에 대한 클래스 </para>
    /// </summary>
    public class MD_Menu_Character : MonoBehaviour
    {
        [Header("- 캐릭터 카드 프리팹")]
        [SerializeField] private GameObject prefab_Card;

        [Header("- 캐릭터 카드를 모아놓은 객체")]
        [SerializeField] private Transform cardPool;

        [Header("- 캐릭터 카드 리스트")]
        [SerializeField] private List<MD_Character_Card> characterList;

        private List<MD_CharacterData> characterDataList;

        private void Start()
        {
            Func_LoadCharacterCardInformation();    // XML에 있는 캐릭터 카드 정보 불러오기
            Func_InstantiateCard();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.11 </para>
        /// <para> 내    용 : XML에 있는 캐릭터 카드 정보 불러오는 기능 </para>
        /// </summary>
        private void Func_LoadCharacterCardInformation()
        {
            characterDataList = MD_XML.Instance.Func_GetCharacterCard();
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.15 </para>
        /// <para> 내    용 : 불러온 캐릭터 카드를 생성하는 기능 </para>
        /// </summary>
        private void Func_InstantiateCard()
        {
            for (int i = 0; i < characterDataList.Count; i++)
            {
                // 카드 생성
                MD_Character_Card _cardOBJ = Instantiate(prefab_Card, cardPool).GetComponent<MD_Character_Card>();
                _cardOBJ.Func_SetCardData(characterDataList[i], i);
                _cardOBJ.characterController = this;

                characterList.Add(_cardOBJ);
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.14 </para>
        /// <para> 내    용 : 해당 캐릭터의 장비창을 여는 기능 </para>
        /// </summary>
        public void Func_PopEquipment(int _num, MD_CharacterData _data)
        {
            MD_PlayManager.Instance.Func_CharacterEquipment(_num, _data);
        }

    }
}