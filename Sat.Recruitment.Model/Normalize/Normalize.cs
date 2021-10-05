using System;

namespace Sat.Recruitment.Core.Normalize
{
    public class Normalize : INormalize
    {
        public string NormalizeEmail(string email)
        {
            var aux = email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            var EmailNormalized = string.Join("@", new string[] { aux[0], aux[1] });
            return EmailNormalized;
        }

    }
}
