using System.Collections.Generic;
using System.Text;
using Kvm.Analyser.Tokens;

namespace Kvm.Analyser
{
    public class Lexer
    {
        private static char[] open = { '{', '%' };
        private static char[] close = { '%', '}' };


        public static List<IToken> Parse(string kvm)
        {
            List<IToken> list = new List<IToken>();
            StringBuilder sb = new StringBuilder();


            bool isOpen = false;

            char lastLastChar = '\0';
            char lastChar = '\0';
            var m = kvm.ToCharArray();
            foreach (var c in m)
            {
                // Open
                if (lastChar == open[0] && c == open[1])
                {
                    if (lastLastChar == '\\')
                    {
                        /* FIXMED: If we only verify 2 digit, how do we check user wants to
                         * input {% or %}?
                         * We should verify 3 digits, like if it is {{% then print {% and etc
                         */
                        sb.Remove(sb.Length - 1, 2).Append("{%");
                        continue;
                    }


                    isOpen = true;

                    list.Add(new BlockToken()
                    {
                        Data = sb.Remove(sb.Length - 1, 1).ToString()
                    });
                    sb.Clear();
                    //}
                }
                // Close
                else if (lastChar == close[0] && c == close[1])
                {
                    if (isOpen)
                    {
                        isOpen = false;
                        list.Add(new ControlToken()
                        {
                            Data = sb.Remove(sb.Length - 1, 1).ToString()
                        });
                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else
                {
                    sb.Append(c);
                }

                lastLastChar = lastChar;
                lastChar = c;
            }
            var s = sb.ToString();
            if (!string.IsNullOrWhiteSpace(s))
            {
                list.Add(new BlockToken()
                {
                    Data = s
                });
            }
            return list;
        }
    }
}