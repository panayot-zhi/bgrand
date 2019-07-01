using System;
using System.Linq;
using System.Numerics;
using System.Text;
using BGRandomGenerator.Models;

namespace BGRandomGenerator.Utility
{
    public static class Generator
    {
        private static readonly Random Rnd = new Random();

        public static bool Percent(int chance)
        {
            return Rnd.Next(100) < chance;
        }

        public static string EGN(DateTime? birthDay, string gender, int? region)
        {
            if (!region.HasValue || region < 0 || region > 999)
            {
                region = Rnd.Next(0, 1000);
            }

            if (!Constants.Genders.Contains(gender))
            {
                gender = Gender();
            }

            if (!birthDay.HasValue)
            {
                birthDay = Date(DateTime.Now.AddYears(-74)); // NOTE: Arbitrary
            }

            var birthDate = birthDay.Value;

            if (gender == "M" && region % 2 != 0)
            {
                region--;
            }
            else if (gender == "F" && region % 2 == 0)
            {
                region++;
            }

            var egnBuilder = new StringBuilder(birthDate.ToString("yyMMdd") + region.Value.ToString("000"));
            if (birthDate.Year > 1999)
            {
                egnBuilder[2] = (int.Parse(egnBuilder[2].ToString()) + 4).ToString()[0];
            }
            else if (birthDate.Year < 1900)
            {
                egnBuilder[2] = (int.Parse(egnBuilder[2].ToString()) + 2).ToString()[0];
            }

            var egn = egnBuilder.ToString();

            int egnsum = 0;
            for (int i = 0; i < 9; i++)
            {
                egnsum +=  (int) char.GetNumericValue( egn[i] ) * Constants.EgnWeights[i];
            }

            int validChecksum = egnsum % 11;
            if (validChecksum == 10)
            {
                validChecksum = 0;
            }

            egn += validChecksum;

            return egn;
        }

        public static string ENCH(DateTime? birthDay, string gender, int? region)
        {
            if (!region.HasValue || region < 0 || region > 999)
            {
                region = Rnd.Next(0, 1000);
            }

            if (!Constants.Genders.Contains(gender))
            {
                gender = Gender();
            }

            if (!birthDay.HasValue)
            {
                birthDay = Date(DateTime.Now.AddYears(-74)); // NOTE: Arbitrary
            }

            var birthDate = birthDay.Value;

            if (gender == "M" && region % 2 != 0)
            {
                region--;
            }
            else if (gender == "F" && region % 2 == 0)
            {
                region++;
            }

            var enchBuilder = new StringBuilder(birthDate.ToString("yyMMdd") + region.Value.ToString("000"));
            if (birthDate.Year > 1999)
            {
                enchBuilder[2] = (int.Parse(enchBuilder[2].ToString()) + 4).ToString()[0];
            }
            else if (birthDate.Year < 1900)
            {
                enchBuilder[2] = (int.Parse(enchBuilder[2].ToString()) + 2).ToString()[0];
            }

            var ench = enchBuilder.ToString();

            int enchsum = 0;
            for (int i = 0; i < 9; i++)
            {                
                enchsum += (int) char.GetNumericValue(ench[i]) * Constants.EnchWeights[i];
            }

            int validChecksum = enchsum % 10;
            ench += validChecksum;

            return ench;
        }

        public static string LNCH()
        {
            const int length = 10;

            int lnchsum = 0;
            var lnchBuilder = new StringBuilder(length);
            for (int i = 0; i < length - 1; i++)
            {
                var randomNumber = Rnd.Next(10);
                lnchBuilder.Insert(i, randomNumber);
                lnchsum += randomNumber * Constants.LnchWeights[i];
            }

            var lnch = lnchBuilder.ToString();

            int validChecksum = lnchsum % 10;
            lnch += validChecksum;

            return lnch;
        }

        public static string BULSTAT(int length)
        {
            switch (length)
            {
                case 9:
                {
                    var bulstatBuilder = new StringBuilder(length);

                    int bulstatsum = 0;
                    for (int i = 0; i < length - 1; i++)
                    {
                        var randomNumber = Rnd.Next(10);
                        bulstatBuilder.Insert(i, randomNumber);
                        bulstatsum += randomNumber * Constants.BulstatWeights[i];
                    }

                    var bulstat = bulstatBuilder.ToString();

                    int validChecksum = bulstatsum % 11;
                    if (validChecksum == 10)
                    {
                        bulstatsum = 0;
                        for (int i = 0; i < length - 1; i++)
                        {
                            bulstatsum += (int) char.GetNumericValue(bulstat[i]) * Constants.BulstatWeights2[i];
                        }

                        validChecksum = bulstatsum % 11;
                        if (validChecksum == 10)
                        {
                            validChecksum = 0;
                        }
                    }

                    bulstat += validChecksum;
                    return bulstat;
                }
                case 10:
                {
                    return EGN(null, null, null);
                }
                case 13:
                {
                    var bulstat = BULSTAT(9);

                    int bulstatsum = 0;
                    for (int i = 8; i < length - 1; i++)
                    {
                        var randomNumber = Rnd.Next(10);
                        bulstat += randomNumber.ToString();
                        bulstatsum += randomNumber * Constants.BulstatWeights[i];
                    }

                    int validChecksum = bulstatsum % 11;
                    if (validChecksum == 10)
                    {
                        bulstatsum = 0;
                        for (int i = 8; i < length - 1; i++)
                        {
                            bulstatsum += (int) char.GetNumericValue(bulstat[i]) * Constants.BulstatWeights2[i];
                        }

                        validChecksum = bulstatsum % 11;
                        if (validChecksum == 10)
                        {
                            validChecksum = 0;
                        }
                    }

                    bulstat += validChecksum;
                    return bulstat;
                }
            }

            throw new ArgumentException("Valid lengths are 9, 10 or 13.", nameof(length));
        }

        public static string IBAN(Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentException("Please pass a banking institution.");
            }
            
            var prefix = "BG00";
            var accountType = Rnd.Next(100).ToString("00");
            var accountNumber = Rnd.Next(100000000).ToString("00000000");            
            var validateable = bank.BankAddressingEntity + accountType + accountNumber + prefix;

            var ibanNumbered = string.Empty;
            foreach (var t in validateable)
            {
                if (t >= 'A' && t <= 'Z')
                {
                    uint number = Convert.ToUInt32(t) - 55;
                    ibanNumbered += number.ToString();
                }
                else
                {
                    ibanNumbered += t;
                }
            }

            var ibanNumber = BigInteger.Parse(ibanNumbered);
            var controlNumber = (98 - (ibanNumber % 97)).ToString("00");
            prefix = prefix.Replace("00", controlNumber);
            
            var iban = prefix + bank.BankAddressingEntity + accountType + accountNumber;

            return iban;
        }

        public static DateTime Date(int startYear)
        {
            return Date(new DateTime(startYear, 1, 1), DateTime.Today);
        }

        public static DateTime Date(int startYear, int endYear)
        {
            return Date(new DateTime(startYear, 1, 1), new DateTime(endYear, 1, 1));
        }

        public static DateTime Date(DateTime startDate)
        {
            return Date(startDate, DateTime.Today);
        }

        public static DateTime Date(DateTime startDate, DateTime endDate)
        {
            var timeSpan = endDate - startDate;
            var randomTimeSpan = new TimeSpan(0, Rnd.Next(0, (int) timeSpan.TotalMinutes), 0);
            return startDate + randomTimeSpan;
        }

        public static string Gender()
        {
            return Constants.Genders.Random();
        }

        public static string PhoneNumber(int? length)
        {
            if (!length.HasValue)
            {
                length = 10;
            }

            string phone;
            switch (length)
            {
                case 10:
                    phone = Constants.MobileOperators.Random();
                    break;
                case 13:
                    phone = Constants.MobileOperators.Random().Replace("0", "+359");
                    break;
                case 14:
                    phone = Constants.MobileOperators.Random().Replace("0", "00359");
                    break;
                default:
                    throw new ArgumentException("Valid lengths are 10, 13 or 14.", nameof(length));
            }
            
            for (int i = 0; i < length; i++)
            {
                phone += Rnd.Next(10);
            }

            return phone;
        }


    }
}
