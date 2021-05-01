using AValentini.Helpers;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour {

    public InputField encryptInputField, decryptInputField;
    public Text encryptedText, decryptedText;

	public void Encrypt()
    {
        if (string.IsNullOrEmpty(encryptInputField.text)) return;
        var input = encryptInputField.text;
        encryptedText.text = Encryption.Encrypt(input);
    }

    public void Decrypt()
    {
        if (string.IsNullOrEmpty(decryptInputField.text)) return;
        var input = decryptInputField.text;
        decryptedText.text = Encryption.Decrypt(input);
    }

    public void CopyEncryptedTextToInputField()
    {
        if (string.IsNullOrEmpty(encryptedText.text)) return;
        decryptInputField.text = encryptedText.text;
    }
}
