using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using DefaultDocumentation.Models;

namespace DefaultDocumentation.Markdown.FileNameFactories;

/// <summary>
/// <see cref="Api.IFileNameFactory"/> implementation using an md5 on the <see cref="DocItem.FullName"/> as file name.
/// </summary>
public sealed class Md5Factory : BaseMarkdownFileNameFactory
{
    /// <summary>
    /// The name of this implementation used at the configuration level.
    /// </summary>
    public const string ConfigName = "Md5";

    /// <inheritdoc/>
    public override string Name => ConfigName;

    /// <inheritdoc/>
    protected override string GetMarkdownFileName(IGeneralContext context, DocItem item)
    {
        context.ThrowIfNull();
        item.ThrowIfNull();

        return GetMd5HashBase36(item.FullName);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA5351:Do Not Use Broken Cryptographic Algorithms", Justification = "not used for security")]
    internal static string GetMd5HashBase36(string text)
    {
        using MD5 md5 = MD5.Create();
        return ToBase36String(md5.ComputeHash(Encoding.UTF8.GetBytes(text)));
    }

    private static string ToBase36String(byte[] bytes)
    {
        // The base 36 alphabet results in concise hashes which are case-insensitive and contain
        // no special characters, ensuring compatibility in a wide range of scenarios
        const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        BigInteger bigInteger = ToNonNegativeBigInteger(bytes);
        StringBuilder result = new();
        while (!bigInteger.IsZero)
        {
            bigInteger = BigInteger.DivRem(bigInteger, Alphabet.Length, out BigInteger remainder);
            result.Append(Alphabet[(int)remainder]);
        }

        if (result.Length == 0)
        {
            result.Append(Alphabet[0]); // ensure the result is never empty
        }

        return result.ToString();
    }

    private static BigInteger ToNonNegativeBigInteger(byte[] bytes)
    {
        byte[] bytesWithTrailingZero = new byte[bytes.Length + 1];
        Array.Copy(bytes, bytesWithTrailingZero, length: bytes.Length);
        return new(bytesWithTrailingZero);
    }
}
