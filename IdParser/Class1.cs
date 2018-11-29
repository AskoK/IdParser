using System;
using System.Globalization;

namespace IdParser
{
    public static class IdParser
    {
        public static bool CodeContainsOnlyNumber(string code)
        {
            return long.TryParse(code, out _);
        }

        public static bool IsLengthValid(string code)
        {
            return code.Length == 11;
        }

        public static string IsMaleOrFemale(string code)
        {
            if (code[0].ToString() == "3" || code[0].ToString() ==  "1" || code[0].ToString() == "5" || code[0].ToString() == "7")
            {
                return "male";
            }
           
            if (code[0].ToString() == "2" || code[0].ToString() == "4" || code[0].ToString() == "6" || code[0].ToString() == "8")
            {
                return "female";
            }
            else
            {
                throw new Exception();
            }
        }

        public static int CheckCentury(string code)
        {
                int century = 0;

                switch (code[0])
                {
                    case '1':
                    case '2':
                        {
                            century = 1800;
                            break;
                        }
                    case '3':
                    case '4':
                        {
                            century = 1900;
                            break;
                        }
                    case '5':
                    case '6':
                        {
                            century = 2000;
                            break;
                        }
                    default:
                        {
                        throw new Exception();
                        }
                }

            return century;
        }

        
        public static bool CheckSum(string code)
        {
            // calculate the checksum
            int n = Int16.Parse(code[0].ToString()) * 1
                  + Int16.Parse(code[1].ToString()) * 2
                  + Int16.Parse(code[2].ToString()) * 3
                  + Int16.Parse(code[3].ToString()) * 4
                  + Int16.Parse(code[4].ToString()) * 5
                  + Int16.Parse(code[5].ToString()) * 6
                  + Int16.Parse(code[6].ToString()) * 7
                  + Int16.Parse(code[7].ToString()) * 8
                  + Int16.Parse(code[8].ToString()) * 9
                  + Int16.Parse(code[9].ToString()) * 1;

            int c = n % 11;

            if (c == 10)
            {
                n = Int16.Parse(code[0].ToString()) * 3
                  + Int16.Parse(code[1].ToString()) * 4
                  + Int16.Parse(code[2].ToString()) * 5
                  + Int16.Parse(code[3].ToString()) * 6
                  + Int16.Parse(code[4].ToString()) * 7
                  + Int16.Parse(code[5].ToString()) * 8
                  + Int16.Parse(code[6].ToString()) * 9
                  + Int16.Parse(code[7].ToString()) * 1
                  + Int16.Parse(code[8].ToString()) * 2
                  + Int16.Parse(code[9].ToString()) * 3;

                c = n % 11;
                c = c % 10;
            }

            return (c == Int16.Parse(code[10].ToString()));
        }


        public static bool ValidStartingNum(string code)
        {
            if (code[0].ToString() == "9" || code[0].ToString() == "0")
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public static string ValidDate(string code)
        {
            int century = 0;

            switch (code[0])
            {
                case '1':
                case '2':
                    {
                        century = 1800;
                        break;
                    }
                case '3':
                case '4':
                    {
                        century = 1900;
                        break;
                    }
                case '5':
                case '6':
                    {
                        century = 2000;
                        break;
                    }
                default:
                    {
                        throw new Exception();
                    }
            }

            string date = code.Substring(5, 2) + "." +
                code.Substring(3, 2) + "." +
                Convert.ToString(century + Convert.ToInt32(code.Substring(1, 2)));

            DateTime dateParse = DateTime.Parse(date, CultureInfo.CurrentCulture);

            return date;
        }
    }
}  
