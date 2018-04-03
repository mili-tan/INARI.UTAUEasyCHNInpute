using System.Collections.Generic;
using System.Xml;

namespace Entity
{
    class PinyinDictionary
    {
        private Dictionary<string, string> dictionary;
        public Dictionary<string, string> Dictionary
        {
            get { return dictionary; }
        }

        public PinyinDictionary() : this("Dictionary\\R-Dictionary.xml")
        { }

        public PinyinDictionary(string fileName)
        {
            dictionary = new Dictionary<string, string>();

            string cn = "";
            string pinyin = "";

            using (XmlTextReader reader = new XmlTextReader(fileName))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        switch (reader.LocalName)
                        {
                            case "InputString":
                                pinyin = reader.ReadElementContentAsString();
                                break;
                            case "OutputString":
                                cn = reader.ReadElementContentAsString();
                                break;
                            case "DictionaryEntry":
                                {
                                    if (!string.IsNullOrEmpty(cn) && !string.IsNullOrEmpty(pinyin))
                                    {
                                        dictionary.Add(cn, pinyin);
                                        cn = "";
                                        pinyin = "";
                                    }
                                }
                                break;
                        }
                    }
                }
            }

        }

        public string GetPinyin(string cn)
        {
            if (string.IsNullOrEmpty(cn))
                return null;

            if (dictionary == null)
                return null;

            if (dictionary.Count == 0)
                return null;

            if (dictionary.ContainsKey(cn))
                return dictionary[cn];

            else
                return null;
        }

        public Dictionary<char, string> GetCnCharPinyin(string cn)
        {
            if (string.IsNullOrEmpty(cn))
                return null;

            if (dictionary == null)
                return null;

            if (dictionary.Count == 0)
                return null;

            if (!dictionary.ContainsKey(cn))
                return null;

            Dictionary<char, string> cnCharPinyin = new Dictionary<char, string>();

            string[] pinyins = dictionary[cn].Split(' ');
            char[] cnChars = cn.ToCharArray();

            for (int i = 0; i < cn.Length; i++)
            {
                cnCharPinyin.Add(cnChars[i], pinyins[i]);
            }

            return cnCharPinyin;
        }

    }
}
