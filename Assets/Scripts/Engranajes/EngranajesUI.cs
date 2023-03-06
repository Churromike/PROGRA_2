using TMPro;
using UnityEngine;

public class EngranajesUI : MonoBehaviour
{

    private TextMeshProUGUI pro;

    private void Start()
    {

        pro = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {

        pro.text = GameManager.instance.engranajes.ToString() + "/10";

    }

}
