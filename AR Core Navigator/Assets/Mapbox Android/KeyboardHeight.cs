using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardHeight : MonoBehaviour 
{
    public InputField inputField;
    public Text textAutocomplete;

    string myText = "";
    
    public RectTransform resultsParent;
    public RectTransform prefab;

    List<string> words = new List<string>();

    public void Update()
    {
        //inputField.keyboardType = (TouchScreenKeyboardType)(-1);
    }
    private void Awake()
    {
        inputField.onValueChanged.AddListener( OnInputValueChanged );
    }

    private void OnInputValueChanged( string newText )
    {
        ClearResults();
        FillResults( GetResults( newText ) );
    }

    private void ClearResults()
    {
        // Reverse loop since you destroy children
        for( int childIndex = resultsParent.childCount - 1 ; childIndex >= 0 ; --childIndex )
        {
            Transform child = resultsParent.GetChild( childIndex );
            child.SetParent( null );
            Destroy( child.gameObject );
        }
    }

    private void FillResults(List<string> results)
    {
        for (int resultIndex = 0 ; resultIndex < results.Count ; resultIndex++)
        {
            RectTransform child = Instantiate( prefab ) as RectTransform;
            child.GetComponentInChildren<Text>().text = results[resultIndex];
            child.SetParent( resultsParent );
        }
    }


    private List<string> GetResults( string input )
    {
        List<string> mockData = new List<string>() { "Paris", "Madrid", "London", "Rome", "Brussels", "Athens", "Dublin", "Lisbon", "Amsterdam", "Luxembourg" };

        return mockData.FindAll( (str) => str.IndexOf( input ) >= 0 );
    }
}



