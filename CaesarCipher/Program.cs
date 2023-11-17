using System;

class CaesarCipher
{
    static void Main(string[] args)
    {
        Console.WriteLine("Caesar Cipher Program");
        Console.Write("Enter a message: ");
        string inStr = Console.ReadLine();
        Console.Write("Enter the shift value (a positive integer): ");
        if (int.TryParse(Console.ReadLine(), out int shiftKey))
        {
            if (shiftKey >= 0)
            {
                shiftKey = shiftKey % 26;
                string encryptedText = encryption(inStr, shiftKey);
                string decryptedText = decryption(encryptedText, shiftKey);

                Console.WriteLine("Encrypted Text: " + encryptedText);
                Console.WriteLine("Decrypted Text: " + decryptedText);
            }
            else
            {
                Console.WriteLine("Shift value must be a positive integer.");
            }
        }
        else
        {
            Console.WriteLine("Invalid shift value. Please enter a positive integer.");
        }
    }

    static string encryption(string text, int key)
    {
        char[] charArray = text.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            if (char.IsLetter(charArray[i]))
            {
                char offset = char.IsUpper(charArray[i]) ? 'A' : 'a';
                charArray[i] = (char)(((charArray[i] + key - offset) % 26) + offset);
            }
        }
        return new string(charArray);
    }

    static string decryption(string text, int key)
    {
        return encryption(text, 26 - key); // Decryption is the same as encryption with the opposite shift
    }
}