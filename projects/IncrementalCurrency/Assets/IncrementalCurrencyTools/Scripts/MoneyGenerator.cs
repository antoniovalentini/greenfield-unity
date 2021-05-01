using UnityEngine;
using UnityEngine.UI;

public class MoneyGenerator : MonoBehaviour
{
    double money = 0;
    public double multiplier;
    public Text moneyText;

    void Start()
    {
        multiplier = 1;
    }

    void Update()
    {
        money += multiplier * Time.deltaTime;
        moneyText.text = string.Format("${0}",money.ToPrettyString());
    }

    // EXAMPLE NUMBERS
    double money1 = 123;        // => 123
    double money2 = 1234;       // => 1.234K
    double money3 = 12345;      // => 12.345K
    double money4 = 123456;     // => 123.456K
    double money5 = 1234567;    // => 1.235M
    double money6 = 12345678;   // => 12.346M
    double money7 = 123456789;  // => 123.457M
    double money8 = 1234567890; // => 1.234B

    // SHOW EXAMPLE NUMBERS
    private void OnGUI()
    {
        var leftAlignStyle = new GUIStyle(GUI.skin.box)
        {
            alignment = TextAnchor.MiddleLeft
        };

        GUILayout.BeginArea(new Rect(10, 10, 320, 250));
        GUILayout.Box("EXAMPLE NUMBERS");
        GUILayout.BeginVertical();
        GUILayout.Box(string.Format("Number: {0} - PrettyNumber: {1} ", money1.ToString("N0"), money1.ToPrettyString()), leftAlignStyle);
        GUILayout.Box(string.Format("Number: {0} - PrettyNumber: {1} ", money2.ToString("N0"), money2.ToPrettyString()), leftAlignStyle);
        GUILayout.Box(string.Format("Number: {0} - PrettyNumber: {1} ", money3.ToString("N0"), money3.ToPrettyString()), leftAlignStyle);
        GUILayout.Box(string.Format("Number: {0} - PrettyNumber: {1} ", money4.ToString("N0"), money4.ToPrettyString()), leftAlignStyle);
        GUILayout.Box(string.Format("Number: {0} - PrettyNumber: {1} ", money5.ToString("N0"), money5.ToPrettyString()), leftAlignStyle);
        GUILayout.Box(string.Format("Number: {0} - PrettyNumber: {1} ", money6.ToString("N0"), money6.ToPrettyString()), leftAlignStyle);
        GUILayout.Box(string.Format("Number: {0} - PrettyNumber: {1} ", money7.ToString("N0"), money7.ToPrettyString()), leftAlignStyle);
        GUILayout.Box(string.Format("Number: {0} - PrettyNumber: {1} ", money8.ToString("N0"), money8.ToPrettyString()), leftAlignStyle);
        GUILayout.EndVertical();
        GUILayout.EndArea();
    }
}
