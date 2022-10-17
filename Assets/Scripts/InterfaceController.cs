using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InterfaceController : MonoBehaviour
{
    [SerializeField] private InputField inputSpeed;
    [SerializeField] private InputField inputDistance;
    [SerializeField] private InputField inputTimeToSpawn;
    [SerializeField] private Text _textHint;
    [SerializeField] private SpawnCubeController spawner;

    List<CubeMovement> listCubes = new List<CubeMovement>();
    Coroutine coroutine;

    System.Globalization.CultureInfo ci = System.Globalization.CultureInfo.GetCultureInfo("en-US");

    private void Start()
    {
        GlobalCubeVars.Speed = 1;
        GlobalCubeVars.Distance = 10;
        _textHint.gameObject.SetActive(false);
    }

    public void OnClickConfirmSettings()
    {
        CubeMovement[] arrayCubes = FindObjectsOfType<CubeMovement>();
        foreach (CubeMovement cube in arrayCubes)
        {
            listCubes.Add(cube);
        }

        try
        {
            foreach (CubeMovement cube in listCubes) // »зменение значений дл€ существующих кубов
            {
                cube.Speed = float.Parse(inputSpeed.text, ci);
                cube.Distance = float.Parse(inputDistance.text, ci);
            }

            GlobalCubeVars.Speed = float.Parse(inputSpeed.text, ci); // »зменение значений дл€ новых кубов с использованием точки и зап€той дл€ преобразовани€
            GlobalCubeVars.Distance = float.Parse(inputDistance.text, ci);
            spawner.TimeToSpawn = float.Parse(inputTimeToSpawn.text, ci);
            ShowTextHint("»зменени€ применены.");
        }
        catch (System.FormatException e)
        {
            ShowTextHint("Ќеверный формат или незаполнены все пол€ настроек");
            //Debug.LogError(e);
        }
    }

    private void ShowTextHint(string text)
    {
        try
        {
            StopCoroutine(coroutine);
        }
        catch { }
        _textHint.color = new Color(_textHint.color.r, _textHint.color.g, _textHint.color.b, 1);
        _textHint.text = text;
        _textHint.gameObject.SetActive(true);
        coroutine = StartCoroutine(TimerToHide_textHint());
    }

    private IEnumerator TimerToHide_textHint()
    {
        yield return new WaitForSeconds(2);
        for (float i = 1; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            _textHint.color = new Color(_textHint.color.r, _textHint.color.g, _textHint.color.b, 1 - i / 100);
        }
        _textHint.gameObject.SetActive(false);
    }
}
