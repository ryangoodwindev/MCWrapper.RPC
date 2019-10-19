using Newtonsoft.Json;
using System;
using System.Text;

namespace MCWrapper.RPC.Extensions
{
    /// <summary>
    /// Helper extensions assist with menial tasks that are required to format data correctly to reside on the MultiChain blockchain network
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convert strongly Typed oject to Hexadecimal String
        /// </summary>
        /// <param name="obj">Pass in strongly Typed object to receive Hexadecimal string representation</param>
        /// <returns></returns>
        public static string ObjectToHex(this object obj) => JsonConvert.SerializeObject(obj).ToHex();

        /// <summary>
        /// Convert Hexadecimal String to strongly Typed Object
        /// </summary>
        /// <typeparam name="T">Generic Type indicates return type</typeparam>
        /// <param name="value">Pass in Hexadecimal string to receive strongly Typed object representation</param>
        /// <returns></returns>
        public static T HexToObject<T>(this string value) => JsonConvert.DeserializeObject<T>(value.FromHex());

        /// <summary>
        /// Convert Byte array to Hexadecimal String
        /// </summary>
        /// <param name="values">Pass in Byte array to reveive Hexadecimal encoded representation</param>
        /// <returns></returns>
        public static string ByteArrayToHex(this byte[] values)
        {
            var sb = new StringBuilder(values.Length * 2);

            foreach (var b in values)
                sb.AppendFormat("{0:x2}", b);

            return sb.ToString();
        }

        /// <summary>
        /// Convert Hexadecimal String to Byte array
        /// </summary>
        /// <param name="hex">Pass in Hexadecimal String to reveive Byte array representation</param>
        /// <returns></returns>
        public static byte[] HexToByteArray(this string hex)
        {
            var numberChars = hex.Length;

            var bytes = new byte[numberChars / 2];

            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);

            return bytes;
        }

        /// <summary>
        /// Convert standard String to Hexadecimal string
        /// </summary>
        /// <param name="str">Pass in String to reveive Hexadecimal representation</param>
        /// <returns></returns>
        public static string ToHex(this string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
                sb.Append(t.ToString("X2"));

            return sb.ToString();
        }

        /// <summary>
        /// Convert Hexadecimal string to standard String
        /// </summary>
        /// <param name="hexString">Pass in Hexadecimal String to reveive String representation</param>
        /// <returns></returns>
        public static string FromHex(this string hexString)
        {
            var bytes = new byte[hexString.Length / 2];

            for (var i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);

            return Encoding.Unicode.GetString(bytes);
        }

        /// <summary>
        /// Convert Hexadecimal String to Base64 encoded String
        /// Useful for storing images in Hexadecimal and then converting to Base64 when retrieved for client viewing
        /// </summary>
        /// <param name="hex">Pass in Hexadecimal String to reveive Base64 encoded representation</param>
        /// <returns></returns>
        public static string ToBase64(this string hex) => Convert.ToBase64String(HexToByteArray(hex));

        /// <summary>
        /// Fetch environment variables by name
        /// Multiple attempts made in order of Process => User => Machine
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetEnvironmentVariable(this string name)
        {
            var value = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process)
                ?? Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.User)
                ?? Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Machine) ?? string.Empty;

            return value;
        }
    }

    /// <summary>
    /// Generate a non-hyphenated GUID
    /// </summary>
    public struct UUID
    {
        public static string NoHyphens => Guid.NewGuid().ToString("N");
    }
}
