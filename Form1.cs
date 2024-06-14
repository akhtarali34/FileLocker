using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace FileLocker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BrowseFile.Click += BrowseFile_Click;
            LockFile.Click += LockFile_Click;
            UnlockFile.Click += UnlockFile_Click;

            // Registering TextChanged event handler for FilePath TextBox
            FilePath.TextChanged += FilePath_TextChanged;
        }

        private void BrowseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void LockFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath.Text))
            {
                MessageBox.Show("Please select a file to lock.");
                return;
            }

            string filePath = FilePath.Text;
            string encryptedFilePath = filePath + ".locked";

            try
            {
                byte[] fileContent = File.ReadAllBytes(filePath);
                byte[] encryptedContent = Encrypt(fileContent, "your-encryption-key");
                File.WriteAllBytes(encryptedFilePath, encryptedContent);
                File.Delete(filePath);

                MessageBox.Show("File locked successfully.");
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void UnlockFile_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath.Text))
            {
                MessageBox.Show("Please select a file to unlock.");
                return;
            }

            string filePath = FilePath.Text;
            if (!filePath.EndsWith(".locked"))
            {
                MessageBox.Show("Please select a locked file.");
                return;
            }

            string decryptedFilePath = filePath.Replace(".locked", "");

            try
            {
                byte[] fileContent = File.ReadAllBytes(filePath);
                byte[] decryptedContent = Decrypt(fileContent, "your-encryption-key");
                File.WriteAllBytes(decryptedFilePath, decryptedContent);
                File.Delete(filePath);

                MessageBox.Show("File unlocked successfully.");
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void FilePath_TextChanged(object sender, EventArgs e)
        {
            // Handle text changed event if needed
            // This method is now defined to handle the TextChanged event of FilePath TextBox
        }

        private byte[] Encrypt(byte[] data, string key)
        {
            using (Aes aes = Aes.Create())
            {
                var keyBytes = Encoding.UTF8.GetBytes(key);
                var keyBytesPadded = new byte[16];
                Array.Copy(keyBytes, keyBytesPadded, Math.Min(keyBytes.Length, keyBytesPadded.Length));
                aes.Key = keyBytesPadded;
                aes.IV = new byte[16];

                using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, encryptor);
                }
            }
        }

        private byte[] Decrypt(byte[] data, string key)
        {
            using (Aes aes = Aes.Create())
            {
                var keyBytes = Encoding.UTF8.GetBytes(key);
                var keyBytesPadded = new byte[16];
                Array.Copy(keyBytes, keyBytesPadded, Math.Min(keyBytes.Length, keyBytesPadded.Length));
                aes.Key = keyBytesPadded;
                aes.IV = new byte[16];

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    return PerformCryptography(data, decryptor);
                }
            }
        }

        private byte[] PerformCryptography(byte[] data, ICryptoTransform cryptoTransform)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                }
                return memoryStream.ToArray();
            }
        }
    }
}
