using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MiniDoodles
{

    public class MDTest : MonoBehaviour
    {
        List<Dictionary<string, object>> _data;
        List<Dictionary<string, object>> _equipData;

        List<Dictionary<string, object>> _data_Character;

        [SerializeField] private MD_Item item;

        private void Start()
        {
            Func_ReadCharacterCard();
        }

        private void Func_ItemRead()
        {
            _data = MD_CSVManager.Read(MD_PathDefine.CSV_ItemListPath);
            _equipData = MD_CSVManager.Read(MD_PathDefine.CSV_ItemEquipListPath);

            for (int i = 0; i < _data.Count; i++)
            {
                Debug.Log("Index : " + i + ": " + _data[i]["id"] + " " + _data[i]["name"] + " " + _data[i]["type"]);
            }

            //item = new MD_Item(int.Parse(_data[0]["id"].ToString()), _data[0]["name"].ToString(), "", (MD_Item.ItemType)_data[0]["type"]);

        }

        private void Func_ReadCharacterCard()
        {
            _data_Character = MD_CSVManager.Read(MD_PathDefine.CSV_CharacterCardListPath);

            Debug.Log(_data_Character.Count);

            for (int i = 0; i < _data_Character.Count; i++)
            {
                Debug.Log("Index : " + i + ": " 
                    + _data_Character[i]["id"] + " " 
                    + _data_Character[i]["name"] + " " 
                    + _data_Character[i]["star"]);

            }
        }
    }
}