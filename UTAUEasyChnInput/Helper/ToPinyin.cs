using Microsoft.International.Converters.PinYinConverter;
using NPinyin;
using System.Text.RegularExpressions;

namespace UTAUEasyChnInput.Helper
{
    public class ToPinyin
    {
        public static string ByNPingyin(char strChar)
        {
            return Regex.Replace(Pinyin.GetPinyin(strChar), @"\d", "").ToLower();
        }

        public static string ByMSIntPinyin(char strChar)
        {
            return Regex.Replace(new ChineseChar(strChar).Pinyins[0].ToString(), @"\d", "").ToLower();
        }
    }
}
