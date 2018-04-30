using System.Collections.Generic;
using System.Linq;

namespace UTAUEasyChnInput.Helper
{
    // by Butaixianran

    static class Segmentation
    {
        /// <summary>
        /// 用最大匹配算法进行分词，正反向均可。
        /// </summary>
        /// <param name="inputStr">要进行分词的字符串</param>
        /// <param name="wordList">词典</param>
        /// <param name="leftToRight">true为从左到右分词，false为从右到左分词</param>
        /// <param name="maxLength">每个分词的最大长度</param>
        /// <returns>储存了分词结果的字符串数组</returns>
        public static List<string> SegMm(string inputStr, ref List<string> wordList, bool leftToRight, int maxLength)
        {
            if (wordList == null)
                return null;

            if (string.IsNullOrEmpty(inputStr))
                return null;

            if (!(maxLength > 0))
                return null;

            List<string> segWords = new List<string>();
            List<string> segWordsReverse = new List<string>();

            string word = "";

            int wordLength = maxLength;
            int position = 0;
            int segLength = 0;

            while (segLength < inputStr.Length)
            {
                if ((inputStr.Length - segLength) < maxLength)
                    wordLength = inputStr.Length - segLength;
                else
                    wordLength = maxLength;

                if (leftToRight)
                    position = segLength;
                else
                    position = inputStr.Length - segLength - wordLength;

                word = inputStr.Substring(position, wordLength);

                while (!wordList.Contains(word))
                {
                    if (word.Length == 1)
                        break;

                    if (leftToRight)
                        word = word.Substring(0, word.Length - 1);
                    else
                        word = word.Substring(1);
                }

                if (leftToRight)
                    segWords.Add(word);
                else
                    segWordsReverse.Add(word);

                segLength += word.Length;

            }

            if (!leftToRight)
            {
                for (int i = 0; i < segWordsReverse.Count; i++)
                {
                    segWords.Add(segWordsReverse[segWordsReverse.Count - 1 - i]);
                }
            }

            return segWords;

        }

        /// <summary>
        /// 用最大匹配算法进行分词，正反向均可，每个分词最大长度是7。
        /// 为了节约内存，词典参数是引用传递
        /// </summary>
        /// <param name="inputStr">要进行分词的字符串</param>
        /// <param name="wordList">词典</param>
        /// <param name="leftToRight">true为从左到右分词，false为从右到左分词</param>
        /// <returns>储存了分词结果的字符串数组</returns>
        public static List<string> SegMm(string inputStr, ref List<string> wordList, bool leftToRight)
        {
            return SegMm(inputStr, ref wordList, leftToRight, 7);
        }

        /// <summary>
        /// 用最大匹配算法进行分词，正向，每个分词最大长度是7。
        /// 为了节约内存，词典参数是引用传递
        /// </summary>
        /// <param name="inputStr">要进行分词的字符串</param>
        /// <param name="wordList">词典</param>
        /// <returns>储存了分词结果的字符串数组</returns>
        public static List<string> SegMmLeftToRight(string inputStr, ref List<string> wordList)
        {
            return SegMm(inputStr, ref wordList, true, 7);
        }

        /// <summary>
        /// 用最大匹配算法进行分词，反向，每个分词最大长度是7。
        /// 为了节约内存，词典参数是引用传递
        /// </summary>
        /// <param name="inputStr">要进行分词的字符串</param>
        /// <param name="wordList">词典</param>
        /// <returns>储存了分词结果的字符串数组</returns>
        public static List<string> SegMmRightToLeft(string inputStr, ref List<string> wordList)
        {
            return SegMm(inputStr, ref wordList, false, 7);
        }

        /// <summary>
        /// 比较两个字符串数组，是否所有内容完全相等。
        /// 为了节约内存，参数是引用传递
        /// </summary>
        /// <param name="strList1">待比较字符串数组01</param>
        /// <param name="strList2">待比较字符串数组02</param>
        /// <returns>完全相同返回true</returns>
        private static bool CompStringList(ref List<string> strList1, ref List<string> strList2)
        {
            if (strList1 == null || strList2 == null)
                return false;

            if (strList1.Count != strList2.Count)
                return false;
            else
            {
                for (int i = 0; i < strList1.Count; i++)
                {
                    if (strList1[i] != strList2[i])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 双向分词
        /// 用最大匹配算法进行分词，双向，每个分词最大长度是7。
        /// 为了节约内存，字典参数是引用传递
        /// </summary>
        /// <param name="inputStr">要进行分词的字符串</param>
        /// <param name="wordList">词典</param>
        /// <returns>储存了分词结果的字符串数组</returns>
        public static List<string> SegMmDouble(string inputStr, ref List<string> wordList)
        {
            List<string> segWordsLeftToRight = new List<string>();
            List<string> segWordsRightToLeft = new List<string>();

            List<string> segWordsFinal = new List<string>();

            List<string> wordsFromLeft = new List<string>();
            List<string> wordsFromRight = new List<string>();
            List<string> wordsAtMiddle = new List<string>();

            segWordsLeftToRight = SegMmLeftToRight(inputStr, ref wordList);
            segWordsRightToLeft = SegMmRightToLeft(inputStr, ref wordList);

            while ((segWordsLeftToRight[0].Length + segWordsRightToLeft[segWordsRightToLeft.Count - 1].Length) < inputStr.Length)
            {

                if (CompStringList(ref segWordsLeftToRight, ref segWordsRightToLeft))
                {
                    wordsAtMiddle = segWordsLeftToRight.ToList<string>();
                    break;
                }

                if (segWordsLeftToRight.Count < segWordsRightToLeft.Count)
                {
                    wordsAtMiddle = segWordsLeftToRight.ToList<string>();
                    break;
                }
                else if (segWordsLeftToRight.Count > segWordsRightToLeft.Count)
                {
                    wordsAtMiddle = segWordsRightToLeft.ToList<string>();
                    break;
                }

                {

                    int singleCharLeftToRight = 0;
                    for (int i = 0; i < segWordsLeftToRight.Count; i++)
                    {
                        if (segWordsLeftToRight[i].Length == 1)
                            singleCharLeftToRight++;
                    }

                    int singleCharRightToLeft = 0;
                    for (int j = 0; j < segWordsRightToLeft.Count; j++)
                    {
                        if (segWordsRightToLeft[j].Length == 1)
                            singleCharRightToLeft++;
                    }

                    if (singleCharLeftToRight < singleCharRightToLeft)
                    {
                        wordsAtMiddle = segWordsLeftToRight.ToList<string>();
                        break;
                    }
                    else if (singleCharLeftToRight > singleCharRightToLeft)
                    {
                        wordsAtMiddle = segWordsRightToLeft.ToList<string>();
                        break;
                    }
                }

                wordsFromLeft.Add(segWordsLeftToRight[0]);
                wordsFromRight.Add(segWordsRightToLeft[segWordsRightToLeft.Count - 1]);

                inputStr = inputStr.Substring(segWordsLeftToRight[0].Length);
                inputStr = inputStr.Substring(0, inputStr.Length - segWordsRightToLeft[segWordsRightToLeft.Count - 1].Length);

                segWordsLeftToRight.Clear();
                segWordsRightToLeft.Clear();

                segWordsLeftToRight = SegMmLeftToRight(inputStr, ref wordList);
                segWordsRightToLeft = SegMmRightToLeft(inputStr, ref wordList);

            }

            if ((segWordsLeftToRight[0].Length + segWordsRightToLeft[segWordsRightToLeft.Count - 1].Length) > inputStr.Length)
            {
                wordsAtMiddle = segWordsLeftToRight.ToList<string>();
            }

            else if ((segWordsLeftToRight[0].Length + segWordsRightToLeft[segWordsRightToLeft.Count - 1].Length) == inputStr.Length)
            {
                wordsAtMiddle.Add(segWordsLeftToRight[0]);
                wordsAtMiddle.Add(segWordsRightToLeft[segWordsRightToLeft.Count - 1]);
            }

            foreach (string wordLeft in wordsFromLeft)
            {
                segWordsFinal.Add(wordLeft);
            }

            foreach (string wordMiddle in wordsAtMiddle)
            {
                segWordsFinal.Add(wordMiddle);
            }

            for (int i = 0; i < wordsFromRight.Count; i++)
            {
                segWordsFinal.Add(wordsFromRight[wordsFromRight.Count - 1 - i]);
            }

            return segWordsFinal;

        }

    }
}
