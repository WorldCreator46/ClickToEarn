using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;
using Newtonsoft.Json;

public class Save : MonoBehaviour
{
    public static char[] RandomLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=".ToCharArray();
    static string password = "";
    private void Start()
    {
        LoadData();
    }
    void ResetData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
    void SaveData()
    {
        PlayerPrefs.SetString("password", password);
        PlayerPrefs.SetString("Property", Encrypt(Property.GetProperty()));
        PlayerPrefs.SetString("Performance", Encrypt(Performance.GetPerformance()));
        PlayerPrefs.Save();
    }
    void LoadData()
    {
        if (CheckData())
        {
            password = PlayerPrefs.GetString("password");
            Property.SetPropert(Decrypt(PlayerPrefs.GetString("Property")));
            Performance.SetPerformance(Decrypt(PlayerPrefs.GetString("Performance")));
        }
        else
        {
            password = ExtractLetters();
        }
    }
    bool CheckData()
    {
        bool check = false;
        if (PlayerPrefs.HasKey("password") && PlayerPrefs.HasKey("Property") && PlayerPrefs.HasKey("Performance"))
        {
            check = true;
        }
        return check;
    }
    public static string ExtractLetters()
    {
        StringBuilder temp = new StringBuilder();
        System.Random random = new System.Random();
        for (int i = 0; i < 16; i++)
        {
            temp.Append(RandomLetters[random.Next(RandomLetters.Length)]);
        }
        return temp.ToString();
    }
    public string Decrypt(string textToDecrypt)
    {
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        rijndaelCipher.Mode = CipherMode.CBC;
        rijndaelCipher.Padding = PaddingMode.PKCS7;
        rijndaelCipher.KeySize = 128;
        rijndaelCipher.BlockSize = 128;
        byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
        byte[] pwdBytes = Encoding.UTF8.GetBytes(password);
        byte[] keyBytes = new byte[16];
        int len = pwdBytes.Length;
        if (len > keyBytes.Length)
        {
            len = keyBytes.Length;
        }
        Array.Copy(pwdBytes, keyBytes, len);
        rijndaelCipher.Key = keyBytes;
        rijndaelCipher.IV = keyBytes;
        byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        return Encoding.UTF8.GetString(plainText);
    }
    public string Encrypt(string textToEncrypt)
    {
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        rijndaelCipher.Mode = CipherMode.CBC;
        rijndaelCipher.Padding = PaddingMode.PKCS7;
        rijndaelCipher.KeySize = 128;
        rijndaelCipher.BlockSize = 128;
        byte[] pwdBytes = Encoding.UTF8.GetBytes(password);
        byte[] keyBytes = new byte[16];
        int len = pwdBytes.Length;
        if (len > keyBytes.Length)
        {
            len = keyBytes.Length;
        }
        Array.Copy(pwdBytes, keyBytes, len);
        rijndaelCipher.Key = keyBytes;
        rijndaelCipher.IV = keyBytes;
        ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
        byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
        return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
    }
    private void OnApplicationQuit()
    {
        SaveData();
    }
}
