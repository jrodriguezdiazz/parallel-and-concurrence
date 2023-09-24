using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

class PasswordHashing
{
  public static string HashPassword(string password)
  {
    // Generate a random salt
    byte[] salt;
    new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

    // Create the password derivation using PBKDF2 with SHA-256
    var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000, HashAlgorithmName.SHA256);
    byte[] hash = pbkdf2.GetBytes(32);

    // Combine the salt and hash into a single byte array
    byte[] hashBytes = new byte[48];
    Array.Copy(salt, 0, hashBytes, 0, 16);
    Array.Copy(hash, 0, hashBytes, 16, 32);

    // Convert the bytes to a base64 representation
    string hashedPassword = Convert.ToBase64String(hashBytes);

    return hashedPassword;
  }

  public static bool VerifyPassword(string hashedPassword, string userPassword)
  {
    // Extract the salt and hash from the stored password
    byte[] hashBytes = Convert.FromBase64String(hashedPassword);
    byte[] salt = new byte[16];
    Array.Copy(hashBytes, 0, salt, 0, 16);

    // Calculate the hash of the provided password and stored salt
    var pbkdf2 = new Rfc2898DeriveBytes(userPassword, salt, 10000, HashAlgorithmName.SHA256);
    byte[] hash = pbkdf2.GetBytes(32);

    // Compare the hashes to verify the password
    for (int i = 0; i < 32; i++)
    {
      if (hashBytes[i + 16] != hash[i])
        return false;
    }

    return true;
  }

  static void Main()
  {
    List<string> originalPasswords = new List<string>
        {
            "Password1",
            "Password2",
            "Password3",
            "Password4",
            "Password5"
        };

    // Store the hashed passwords in the database
    List<string> hashedPasswords = new List<string>();
    Parallel.ForEach(originalPasswords, (password) =>
    {
      string hashedPassword = HashPassword(password);
      lock (hashedPasswords) // Lock to ensure thread-safe access
      {
        hashedPasswords.Add(hashedPassword);
      }
    });

    // Verify user-entered passwords in parallel
    string userPassword = "Password1";
    Parallel.ForEach(hashedPasswords, (hashedPassword) =>
    {
      bool match = VerifyPassword(hashedPassword, userPassword);
      if (match)
        Console.WriteLine($"Password Match: {userPassword}");
    });
  }
}
