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
        private XmlDocument characterXML;

        [HideInInspector]
        public bool isExist = false;

        protected override void Awake()
        {
            Func_LoadPlayerXML();
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
            Debug.Log("Player XML Save Success");
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.11 </para>
        /// <para> 내    용 : 캐릭터 XML 파일을 생성하는 메서드 </para>
        /// </summary>
        private void Func_CreateCharacterInfoXML()
        {
            // xml 선언
            XmlDocument _xmlDoc = new XmlDocument();
            // xml 버전과 인코딩 방식 설정
            _xmlDoc.AppendChild(_xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "yes"));

            #region Setting Node

            // 루트 노드 생성
            XmlNode _rootSet = _xmlDoc.CreateNode(XmlNodeType.Element, "CharacterInfo", string.Empty);
            _xmlDoc.AppendChild(_rootSet);

            // 자식 노드 생성
            XmlNode _childSet = _xmlDoc.CreateNode(XmlNodeType.Element, "Character", string.Empty);
            _rootSet.AppendChild(_childSet);

            // 자식노드에 들어갈 속성 생성
            XmlElement _setDate = _xmlDoc.CreateElement("Date");
            _setDate.InnerText = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            _childSet.AppendChild(_setDate);

            #endregion

            _xmlDoc.Save(MD_PathDefine.XML_SavePath + MD_PathDefine.XML_CharacterInformation + ".xml");
            Debug.Log("Character XML Save Success");
        }

        #endregion

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
                Debug.Log("Save 없음!");
                Func_CreatePlayerInfoXML();
            }
        }

        /// <summary>
        /// <para> 작 성 자 : 이승엽 </para>
        /// <para> 작 성 일 : 2020.12.11 </para>
        /// <para> 내    용 : 캐릭터 XML 파일을 불러오는 메서드 </para>
        /// </summary>
        private void Func_LoadCharacterXML()
        {
            TextAsset _textAsset = (TextAsset)Resources.Load("XML/" + MD_PathDefine.XML_CharacterInformation);

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
                Debug.Log("Save 없음!");

            }
        }
    }
}