namespace Islam.Core
{   //used Porter stemming algorithm  
	class Stemming
    {
        
        private char[] arrayOfChar;
        private int endIndex;
        private int stemIndex;


        public string DoStemming(string word)
        {

            if (string.IsNullOrWhiteSpace(word) || word.Length <= 2) return word;
            word = word.ToLower();
            arrayOfChar = word.ToCharArray();
            stemIndex = 0;
            endIndex = word.Length - 1;
            Step1a();
            Step1b();
            Step1c();
            Step2();
            Step3();
            Step4();
            Step5a();
            Step5b();
            return new string(arrayOfChar, 0, ++endIndex );
        }

        private bool IsConsonant(int index)
        {
			char c = arrayOfChar[index];
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') return false;
            return c != 'y' || (index == 0 || !IsConsonant(index - 1));
        }


        private int Measure()
        {
			int n = 0;
			int index = 0;
            while (true)
            {
                if (index > stemIndex) return n;
                if (!IsConsonant(index)) break; index++;
            }
            index++;
            while (true)
            {
                while (true)
                {
                    if (index > stemIndex) return n;
                    if (IsConsonant(index)) break;
                    index++;
                }
                index++;
                n++;
                while (true)
                {
                    if (index > stemIndex) return n;
                    if (!IsConsonant(index)) break;
                    index++;
                }
                index++;
            }
        }

        private bool IsStemContainsVowel()
        {
            int i;
            for (i = 0; i <= stemIndex; i++)
            {
                if (!IsConsonant(i)) return true;
            }
            return false;
        }

        private bool IsDoubleConsontant(int index)
        {
            if (index < 1) return false;
            return arrayOfChar[index] == arrayOfChar[index - 1] && IsConsonant(index);
        }

        private bool IsCVC(int index)
        {
            if (index < 2 || !IsConsonant(index) || IsConsonant(index - 1) || !IsConsonant(index - 2)) return false;
			char c = arrayOfChar[index];
            return c != 'w' && c != 'x' && c != 'y';
        }

        private bool EndsWith(string s)
        {
			int length = s.Length;
			int index = endIndex - length + 1;
            if (index < 0) return false;

            for (int i = 0; i < length; i++)
            {
                if (arrayOfChar[index + i] != s[i]) return false;
            }
            stemIndex = endIndex - length;
            return true;
        }

        private void SetEnd(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                arrayOfChar[stemIndex + 1 + i] = s[i];
            }
            endIndex = stemIndex + s.Length ;
        }

        private void ReplaceEnd(string s)
        {
            if (Measure() > 0) SetEnd(s);
        }

        private void Step1a()
        {
            if (arrayOfChar[endIndex] == 's')
            {
                if (EndsWith("sses"))
                {
                    endIndex -= 2;
                }
                else if (EndsWith("ies"))
                {
                    SetEnd("i");
                }
                else if (arrayOfChar[endIndex - 1] != 's')
                {
                    endIndex--;
                }
            }
        }
        private void Step1b()
        {
            if (EndsWith("eed"))
            {
                if (Measure() > 0)
                    endIndex--;
            }
            else if ((EndsWith("ed") || EndsWith("ing")) && IsStemContainsVowel())
            {
                endIndex = stemIndex;
                if (EndsWith("at"))
                    SetEnd("ate");
                else if (EndsWith("bl"))
                    SetEnd("ble");
                else if (EndsWith("iz"))
                    SetEnd("ize");
                else if (IsDoubleConsontant(endIndex))
                {
                    endIndex--;
                    int ch = arrayOfChar[endIndex];
                    if (ch == 'l' || ch == 's' || ch == 'z')
                        endIndex++;
                }
                else if (Measure() == 1 && IsCVC(endIndex)) SetEnd("e");
            }
        }

        private void Step1c()
        {
            if (EndsWith("y") && IsStemContainsVowel())
                arrayOfChar[endIndex] = 'i';
        }


        private void Step2()
        {
            if (endIndex == 0) return;

            switch (arrayOfChar[endIndex - 1])
            {
                case 'a':
                    if (EndsWith("ational")) { ReplaceEnd("ate"); break; }
                    if (EndsWith("tional")) { ReplaceEnd("tion"); }
                    break;
                case 'c':
                    if (EndsWith("enci")) { ReplaceEnd("ence"); break; }
                    if (EndsWith("anci")) { ReplaceEnd("ance"); }
                    break;
                case 'e':
                    if (EndsWith("izer")) { ReplaceEnd("ize"); }
                    break;
                case 'l':
                    if (EndsWith("bli")) { ReplaceEnd("ble"); break; }
                    if (EndsWith("alli")) { ReplaceEnd("al"); break; }
                    if (EndsWith("entli")) { ReplaceEnd("ent"); break; }
                    if (EndsWith("eli")) { ReplaceEnd("e"); break; }
                    if (EndsWith("ousli")) { ReplaceEnd("ous"); }
                    break;
                case 'o':
                    if (EndsWith("ization")) { ReplaceEnd("ize"); break; }
                    if (EndsWith("ation")) { ReplaceEnd("ate"); break; }
                    if (EndsWith("ator")) { ReplaceEnd("ate"); }
                    break;
                case 's':
                    if (EndsWith("alism")) { ReplaceEnd("al"); break; }
                    if (EndsWith("iveness")) { ReplaceEnd("ive"); break; }
                    if (EndsWith("fulness")) { ReplaceEnd("ful"); break; }
                    if (EndsWith("ousness")) { ReplaceEnd("ous"); }
                    break;
                case 't':
                    if (EndsWith("aliti")) { ReplaceEnd("al"); break; }
                    if (EndsWith("iviti")) { ReplaceEnd("ive"); break; }
                    if (EndsWith("biliti")) { ReplaceEnd("ble"); }
                    break;
                case 'g':
                    if (EndsWith("logi"))
                    {
                        ReplaceEnd("log");
                    }
                    break;
            }
        }


        private void Step3()
        {
            switch (arrayOfChar[endIndex])
            {
                case 'e':
                    if (EndsWith("icate")) { ReplaceEnd("ic"); break; }
                    if (EndsWith("ative")) { ReplaceEnd(""); break; }
                    if (EndsWith("alize")) { ReplaceEnd("al"); }
                    break;
                case 'i':
                    if (EndsWith("iciti")) { ReplaceEnd("ic"); }
                    break;
                case 'l':
                    if (EndsWith("ical")) { ReplaceEnd("ic"); break; }
                    if (EndsWith("ful")) { ReplaceEnd(""); }
                    break;
                case 's':
                    if (EndsWith("ness")) { ReplaceEnd(""); }
                    break;
            }
        }

        private void Step4()
        {
            if (endIndex == 0) return;

            switch (arrayOfChar[endIndex - 1])
            {
                case 'a':
                    if (EndsWith("al")) break;
                    return;
                case 'c':
                    if (EndsWith("ance")) break;
                    if (EndsWith("ence")) break;
                    return;
                case 'e':
                    if (EndsWith("er")) break;
                    return;
                case 'i':
                    if (EndsWith("ic")) break;
                    return;
                case 'l':
                    if (EndsWith("able")) break;
                    if (EndsWith("ible")) break;
                    return;
                case 'n':
                    if (EndsWith("ant")) break;
                    if (EndsWith("ement")) break;
                    if (EndsWith("ment")) break;
                    if (EndsWith("ent")) break;
                    return;
                case 'o':
                    if (EndsWith("ion") && stemIndex >= 0 && (arrayOfChar[stemIndex] == 's' || arrayOfChar[stemIndex] == 't')) break;
                    if (EndsWith("ou")) break;
                    return;
                case 's':
                    if (EndsWith("ism")) break;
                    return;
                case 't':
                    if (EndsWith("ate")) break;
                    if (EndsWith("iti")) break;
                    return;
                case 'u':
                    if (EndsWith("ous")) break;
                    return;
                case 'v':
                    if (EndsWith("ive")) break;
                    return;
                case 'z':
                    if (EndsWith("ize")) break;
                    return;
                default:
                    return;
            }
            if (Measure() > 1)
                endIndex = stemIndex;
        }

        private void Step5a()
        {
            stemIndex = endIndex;

            if (arrayOfChar[endIndex] == 'e')
            {
                var a = Measure();
                if (a > 1 || a == 1 && !IsCVC(endIndex - 1))
                    endIndex--;
            }

        }
        private void Step5b()
        {
            stemIndex = endIndex;
            if (arrayOfChar[endIndex] == 'l' && IsDoubleConsontant(endIndex) && Measure() > 1)
                endIndex--;
        }
    }


}

