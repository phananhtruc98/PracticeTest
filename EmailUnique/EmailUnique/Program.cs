using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailUnique
{
    class Program
    {
        public static void NumUniqueEmails(string[] emails)
        {
            for (int i = 0; i < emails.Length; i++)
            {
                StartWithPlus(emails[i]);
            }
        }

        public static bool StartWithPlus(String email)
        {
            char[] ch = email.ToCharArray();
            if (ch[0].ToString() == "+")
            {
                Console.WriteLine("Email không đúng");
                return false;
            }
            else return true;
        }
        public static bool CheckLengthArray(String[] emails)
        {
            if (emails.Length >= 1 && emails.Length <= 100)
                return true;
            return false;
        }
        public static bool CheckLengthListMail(String[] emails)
        {
            foreach (String e in emails)
            {
                if (CheckLengthEmail(e) == false)
                    return false;
            }
            return true;
        }
        public static bool CheckLengthEmail(String email)
        {
            char[] ch = email.ToCharArray();
            if (ch.Length >= 1 && ch.Length <= 100)
                return true;
            return false;
        }

        public static String RemoveDot(String email)
        {
            String[] arr = email.Split('@');
            String str1 = arr[0].Replace(".", string.Empty);
            String[] arr1 = str1.Split('+');
            String localName = arr1[0];
            return localName + "@" + arr[1];
        }

        public static List<String> Result(String[] emails)
        {
            List<String> rs = new List<string>();
            foreach (String e in emails)
            {
                String s = RemoveDot(e);
                rs.Add(s);
            }
            return rs;
        }
        static void Main(string[] args)
        {
            Encoding u8 = Encoding.UTF8;
            string[] emails = { "test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com" };
            if (!CheckLengthArray(emails)) { Console.WriteLine("Vượt quá số lượng email cho phép"); }
            if (!CheckLengthListMail(emails)) { Console.WriteLine("Email quá dài"); }
            NumUniqueEmails(emails);
            List<string> emails1 = Result(emails).Distinct().ToList();
            foreach (String e in emails1)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }
    }
}
