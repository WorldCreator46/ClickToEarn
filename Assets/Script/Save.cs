using UnityEngine;
using System.Security.Cryptography;
using System.Text;
using System;

public class Save : MonoBehaviour
{
    public static char[] RandomLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=".ToCharArray();
    static string password = "";
    static bool FirstStart = true;
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private void Awake()
    {
        ResetData();
        if (FirstStart)
        {
            LoadData();
            FirstStart = false;
        }
    }
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
    public static void SaveData()
    {
        PlayerPrefs.SetString("password", password);
        PlayerPrefs.SetString("Property", Encrypt(Property.GetProperty()));
        PlayerPrefs.SetString("Skill", Encrypt(Skill.GetSkill()));
        PlayerPrefs.SetString("Performance", Encrypt(Performance.GetPerformance()));
        PlayerPrefs.SetString("CrystalGrade", Encrypt(CrystalUpgrade.GetGrade()));
        PlayerPrefs.Save();
    }
    void LoadData()
    {
        if (CheckData())
        {
            password = PlayerPrefs.GetString("password");
            Property.SetPropert(Decrypt(PlayerPrefs.GetString("Property")));
            Skill.SetSkill(Decrypt(PlayerPrefs.GetString("Skill")));
            Performance.SetPerformance(Decrypt(PlayerPrefs.GetString("Performance")));
            CrystalUpgrade.SetGrade(Decrypt(PlayerPrefs.GetString("CrystalGrade")));
        }
        else
        {
            ResetData();
            password = ExtractLetters();
        }
    }
    bool CheckData()
    {
        bool check = false;
        if (PlayerPrefs.HasKey("password") && PlayerPrefs.HasKey("Property") && PlayerPrefs.HasKey("Performance") && PlayerPrefs.HasKey("Skill") && PlayerPrefs.HasKey("CrystalGrade"))
        {
            check = true;
        }
        return check;
    }
    private static string ExtractLetters()
    {
        StringBuilder temp = new StringBuilder();
        System.Random random = new System.Random();
        for (int i = 0; i < 16; i++)
        {
            temp.Append(RandomLetters[random.Next(RandomLetters.Length)]);
        }
        return temp.ToString();
    }
    private static string Decrypt(string textToDecrypt)
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
    public static string Encrypt(string textToEncrypt)
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
