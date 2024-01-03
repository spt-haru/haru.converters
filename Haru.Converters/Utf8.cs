using System;
using System.Text;
using Haru.Pools;

namespace Haru.Converters
{
    public class Utf8
    {
        private static readonly UTF8Encoding _encoding;

        static Utf8()
        {
            _encoding = new UTF8Encoding();
        }

        public static ReadOnlySpan<byte> ToBytes(ReadOnlySpan<char> s)
        {
            var buffer = ByteArrayPool.Rent(s.Length);

            try
            {
                _encoding.GetBytes(s.ToArray(), 0, s.Length, buffer, 0);
                return buffer;
            }
            finally
            {
                ByteArrayPool.Return(buffer);
            }
        }

        public static ReadOnlySpan<byte> ToBytes(string s)
        {
            return ToBytes(s.AsSpan());
        }

        public static ReadOnlySpan<char> ToChars(ReadOnlySpan<byte> data)
        {
            return _encoding.GetChars(data.ToArray(), 0, data.Length);
        }

        public static string ToString(ReadOnlySpan<byte> data)
        {
            return _encoding.GetString(data.ToArray(), 0, data.Length);
        }
    }
}