using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownEvent : MonoBehaviour {

    private Dropdown dd;
    private Resolution[] reso;
    private List<Dropdown.OptionData> odList = new List<Dropdown.OptionData>();

    // Use this for initialization
    void Start () {
        reso = Screen.resolutions;
        dd = this.GetComponent<Dropdown>();
        dd.options.Clear();
        foreach (Resolution res in reso)
        {
            Dropdown.OptionData tmp = new Dropdown.OptionData();
            tmp.text = res.width + "X" + res.height;
            dd.options.Add(tmp);
            dd.onValueChanged.AddListener(index =>
            {
                dd.captionText.text = reso[index].width + "X" + reso[index].height;
                Screen.SetResolution(reso[index].width, reso[index].height, false);
            });
        }
	}
}
