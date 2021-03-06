﻿using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace MiniDoodles
{
    /// <summary>
    /// <para>작 성 자 : 이승엽</para>
    /// <para>작 성 일 : 2020.05.16</para>
    /// <para>내    용 : CSV파일을 읽어오는 스크립트</para>
    /// </summary>
    public class MD_CSVManager
    {
        static string SPLIT = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
        static string LINE_SPLIT = @"\r\n|\n\r|\n|\r";
        static char[] TRIM_CHAR_ARR = { '\"' };

        public static List<Dictionary<string, object>> Read(string _file)
        {
            var _list = new List<Dictionary<string, object>>();
            TextAsset _data = Resources.Load(_file) as TextAsset;

            var _line = Regex.Split(_data.text, LINE_SPLIT);
            if (_line.Length <= 1)
            {
                return _list;
            }

            var _header = Regex.Split(_line[0], SPLIT);
            for (int i = 1; i < _line.Length; i++)
            {
                var _values = Regex.Split(_line[i], SPLIT);
                if (_values.Length == 0 || _values[0] == "")
                {
                    continue;
                }

                var _entry = new Dictionary<string, object>();
                for (int j = 0; j < _header.Length && j < _values.Length; j++)
                {
                    string _value = _values[j];
                    _value = _value.TrimStart(TRIM_CHAR_ARR).TrimEnd(TRIM_CHAR_ARR).Replace("\\", "");
                    _value = _value.Replace("<br>", "\n");
                    _value = _value.Replace("<c>", ",");

                    object _finalValue = _value;
                    int _n;
                    float _f;

                    if (int.TryParse(_value, out _n))
                    {
                        _finalValue = _n;
                    }
                    else if(float.TryParse(_value, out _f))
                    {
                        _finalValue = _f;
                    }

                    _entry[_header[j]] = _finalValue;
                }

                _list.Add(_entry);
            }

            return _list;
        }
    }
}