namespace System.Text
{
    internal static class StringBuilderExtension
    {
        public static bool EndsWith(this StringBuilder builder, string value)
        {
            if (builder.Length < value.Length)
            {
                return false;
            }

            for (int i = 0; i < value.Length; ++i)
            {
                if (value[i] != builder[builder.Length - value.Length + i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
