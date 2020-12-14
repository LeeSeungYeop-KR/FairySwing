using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para> 작 성 자 : 이승엽 </para>
    /// <para> 작 성 일 : 2020.04.04 </para>
    /// <para> 내    용 : XML을 관리하는 스크립트 </para>
    /// </summary>
    public class MD_XML : MD_Singlton<MD_XML>
    {
        [Header("- 플레이어 XML")]
        private XmlDocument playerXML;

        [Header("- 캐릭터 XML")]
        private XmlElement characterXML;

        [HideInInspector]
        public bool isExist = false;

        protected override void Func_Init()
        {
            Func_LoadPlayerXML();
            Func_LoadCharacterCardXML();
        }

        #region Create XML

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : 플레이어 XML 파일을 생성하는 메서드 </para>
        /// </summary>
        private void Func_CreatePlayerInfoXML()
        {
            // xml 선언
            XmlDocument _xmlDoc = new XmlDocument();
            // xml 버전과 인코딩 방식 설정
            _xmlDoc.AppendChild(_xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            #region Setting Node

            // 루트 노드 생성
            XmlNode _rootSet = _xmlDoc.CreateNode(XmlNodeType.Element, "SettingInfo", string.Empty);
            _xmlDoc.AppendChild(_rootSet);

            // 자식 노드 생성
            XmlNode _childSet = _xmlDoc.CreateNode(XmlNodeType.Element, "Setting", string.Empty);
            _rootSet.AppendChild(_childSet);

            // 자식노드에 들어갈 속성 생성
            XmlElement _setDate = _xmlDoc.CreateElement("Date");
            _setDate.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            _childSet.AppendChild(_setDate);

            #endregion

            _xmlDoc.Save(MD_PathDefine.XML_SavePath + MD_PathDefine.XML_PlayerInformation + ".xml");
            Debug.Log(MD_PathDefine.XML_PlayerInformation + " XML Save Success");
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.11 </para>
        /// <para> 내    용 : 캐릭터 XML 파일을 생성하는 메서드 </para>
        /// </summary>
        private void Func_CreateCharacterCardInfoXML()
        {
            // xml 선언
            XmlDocument _xmlDoc = new XmlDocument();
            // xml 버전과 인코딩 방식 설정
            _xmlDoc.AppendChild(_xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            #region Setting Node

            // 루트 노드 생성
            XmlNode _rootSet = _xmlDoc.CreateNode(XmlNodeType.Element, "CharacterCardInfo", string.Empty);
            _xmlDoc.AppendChild(_rootSet);

            // 자식 노드 생성
            XmlElement _childSet = _xmlDoc.CreateElement("CharacterCard");
            _childSet.SetAttribute("ID", "0");      // id
            _childSet.SetAttribute("Name", "뽀용");      // Name
            _childSet.SetAttribute("Rare", "1");      // Rare
            _childSet.SetAttribute("Level", "1");      // Level
            _childSet.SetAttribute("ImageNum", "0");      // ImageNum

            _rootSet.AppendChild(_childSet);

            #endregion

            _xmlDoc.Save(MD_PathDefine.XML_SavePath + MD_PathDefine.XML_CharacterCardInformation + ".xml");
            Debug.Log(MD_PathDefine.XML_CharacterCardInformation + " XML Save Success");
        }

        #endregion

        #region Load XML

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.04.04 </para>
        /// <para> 내    용 : XML 파일을 불러오는 메서드 </para>
        /// </summary>
        private void Func_LoadPlayerXML()
        {
            TextAsset _textAsset = (TextAsset)Resources.Load("XML/" + MD_PathDefine.XML_PlayerInformation);

            if (_textAsset != null)
            {
                isExist = true;

                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.LoadXml(_textAsset.text);

                XmlNodeList _nodes = _xmlDoc.SelectNodes(MD_PathDefine.XML_Node_Setting);

                _nodes[0].SelectSingleNode("Date").InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                Debug.Log(_nodes[0].SelectSingleNode("Date").InnerText);
            }
            else
            {
                Debug.Log(MD_PathDefine.XML_PlayerInformation + "Save 없음!");
                Func_CreatePlayerInfoXML();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.11 </para>
        /// <para> 내    용 : 캐릭터 카드 XML 파일을 불러오는 메서드 </para>
        /// </summary>
        private void Func_LoadCharacterCardXML()
        {
            TextAsset _textAsset = Resources.Load("XML/" + MD_PathDefine.XML_CharacterCardInformation) as TextAsset;

            if (_textAsset != null)
            {
                isExist = true;

                XmlDocument _xmlDoc = new XmlDocument();
                _xmlDoc.LoadXml(_textAsset.text);
                characterXML = _xmlDoc["CharacterCardInfo"];

                Debug.Log("가지고 있는 캐릭터의 개수 : " + characterXML.ChildNodes.Count);
            }
            else
            {
                Debug.Log(MD_PathDefine.XML_CharacterCardInformation + "Save 없음!");

            }
        }

        #endregion

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.15 </para>
        /// <para> 내    용 : 캐릭터 카드가 있는 만큼 리스트를 생성하여 건네주는 메서드 </para>
        /// </summary>
        public List<MD_CharacterData> Func_GetCharacterCard()
        {
            List<MD_CharacterData> _characterCardList = new List<MD_CharacterData>();
            int _num = 0;

            foreach (XmlElement item in characterXML.ChildNodes)
            {
                MD_CharacterData _cardData = new MD_CharacterData();
                _num++;     // 횟수 증가

                _cardData.data_ID = int.Parse(item.GetAttribute("ID"));         // 아이디 값
                _cardData.data_name = item.GetAttribute("Name");                // 이름
                _cardData.data_level = int.Parse(item.GetAttribute("Level"));   // 레벨
                _cardData.data_StarNum = int.Parse(item.GetAttribute("Rare"));  // Rare
                
                _characterCardList.Add(_cardData);                      // 카드 추가
            }

            return _characterCardList;
        }
    }
}