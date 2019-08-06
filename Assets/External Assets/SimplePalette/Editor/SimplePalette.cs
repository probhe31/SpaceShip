using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SimplePalette : EditorWindow, IHasCustomMenu
{
    bool groupEnabled;
    List<string> colors = new List<string>();
   
    private TextAsset textAsset;

    [MenuItem("Window/SimplePalette")]
    static void Init()
    {
        SimplePalette window = (SimplePalette)EditorWindow.GetWindow(typeof(SimplePalette));
        window.Show();
    }

    public GUISkin customSkin;
    string currentColor="";

    bool loaded = false;


    
    void OnGUI()
    {
        GUI.skin = customSkin;
       

        if (!loaded)
        {
            GUI.backgroundColor = new Color(0.13f, 0.13f, 0.13f);

            if(GUILayout.Button("Format: Paint.net .TXT \n You can get palettes on: \n https://lospec.com/palette-list"))
            {
                OpenLospec();
            }

            GUILayout.Space(20);
            GUILayout.Label("Source:");
            textAsset = EditorGUILayout.ObjectField("", textAsset, typeof(TextAsset), false) as TextAsset;

            if (textAsset == null)
            {
                GUI.enabled = false;
            }

            GUILayout.Space(20);
            GUI.backgroundColor = Color.gray;
            if (GUILayout.Button("Load", GUILayout.Height(50)))
            {

                LoadPalette();
                
            }
        }
        

        if (colors.Count <= 0)
            return;

        GUILayout.Label(paletteName, EditorStyles.boldLabel);

        int acum = 0;
        do
        {
            GUILayout.BeginHorizontal();
            for (int k = 0; k < 4; k++)
            {
                if (acum < colors.Count)
                {
                    Color newcol;
                    if (ColorUtility.TryParseHtmlString("#" + colors[acum], out newcol))
                    {
                        newcol.a = 1;
                        GUI.backgroundColor = newcol;
                    }

                    if (GUILayout.Button(""))
                    {
                        this.CopyColor(colors[acum]);
                        this.currentColor = colors[acum];
                    }

                    acum++;
                }
                else
                {

                    //GUI.backgroundColor = new Color(0.22f, 0.22f, 0.22f);
                    GUI.backgroundColor = Color.black;
                    GUILayout.Button("");

                }
            }
            GUILayout.EndHorizontal();

        } while (acum < colors.Count);

        GUILayout.Label("Color: #" + currentColor, EditorStyles.boldLabel);
    }

    string paletteName = "Palette: Unknow";

    private void LoadPalette()
    {
        int cc = 0;

        Debug.Log("ss " + textAsset.text.Substring(0, 1));
        
        if (textAsset.text.Substring(0, 1) != ";")
        {
            ClearPalette();
            return;
        }

        this.loaded = true;


        string[] lines = textAsset.text.Split(new char[] { '\n' });

        


        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length < 1)
                continue;

            if (lines[i].Substring(0, 1) != ";")
            {
                colors.Add(lines[i].Substring(2, lines[i].Length-3));
            }
            else
            {  

                if (cc == 2)
                {
                    paletteName = "Palette: " + lines[i].Substring(15, lines[i].Length-16);
                }
                cc++;
            }          
        }


        
    }

    private void CopyColor(string copyText)
    {
        var textEditor = new TextEditor();
        textEditor.text = copyText;
        textEditor.SelectAll();
        textEditor.Copy();
    }

    private GUIContent m_MenuItem1 = new GUIContent("Clear palette");
    private GUIContent m_MenuItem2 = new GUIContent("Open Lospec");

    public void AddItemsToMenu(GenericMenu menu)
    {
        menu.AddItem(m_MenuItem1, false, ClearPalette);
        menu.AddItem(m_MenuItem2, false, OpenLospec);
       
    }

    void ClearPalette()
    {
        colors = new List<string>();
        loaded = false;
        textAsset = null;
    }

    void OpenLospec()
    {
        Application.OpenURL("https://lospec.com/palette-list");
    }
}
