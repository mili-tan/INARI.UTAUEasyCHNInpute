using Microsoft.International.Converters.PinYinConverter;
using NPinyin;
using System.Text.RegularExpressions;

namespace UTAUEasyChnInput.Helper
{
    public static class ToPinyin
    {
        public static string ByNPingyin(char strChar)
        {
            return Regex.Replace(Pinyin.GetPinyin(strChar), @"\d", "").ToLower();
        }

        public static string ByMsIntPinyin(char strChar)
        {
            return Regex.Replace(new ChineseChar(strChar).Pinyins[0], @"\d", "").ToLower();
        }
    }
}
