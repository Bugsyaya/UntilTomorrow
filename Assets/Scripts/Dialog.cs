using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Dialog : MonoBehaviour
{
    private Text _textComponent;

    public string[] DialogueStrings;

    public float SecondsBetweenCharacters = 0.15f;
    public float CharacterRateMultiplier = 0.5f;

    public KeyCode DialogueInput = KeyCode.Return;

    private bool _isStringBeingRevealed = false;
    private bool _isDialoguePlaying = false;
    public bool finished = false;
    

    //public GameObject ContinueIcon;
    //public GameObject StopIcon;

    // Use this for initialization
    void Start ()
    {
        _textComponent = GetComponent<Text>();
        _textComponent.text = "";

        //HideIcons();
    }

    public void BeginDialog(string[] strings)
    {
        DialogueStrings = strings;

        if (!_isDialoguePlaying)
        {
            _isDialoguePlaying = true;
            StartCoroutine(StartDialogue());
        }
    }

    private IEnumerator StartDialogue()
    {
        int dialogueLength = DialogueStrings.Length;
        int currentDialogueIndex = 0;

        while (currentDialogueIndex < dialogueLength)
        {
            if (!_isStringBeingRevealed)
            {
                _isStringBeingRevealed = true;
                StartCoroutine(DisplayString(DialogueStrings[currentDialogueIndex]));
				currentDialogueIndex++;

				//ShowIcon();

				while (!Input.GetKeyDown(DialogueInput) || _isStringBeingRevealed)
                {
                    yield return 0;
                }
                Debug.Log("Stop wainting");

                //HideIcons();

                if (currentDialogueIndex >= dialogueLength)
                {
                    finished = true;
					_textComponent.text = "";
                }
            }

            yield return 0;
        }
        
        _isDialoguePlaying = false;
    }

    private IEnumerator DisplayString(string stringToDisplay)
    {
        int stringLength = stringToDisplay.Length;
        int currentCharacterIndex = 0;

        //HideIcons();

        _textComponent.text = "";

        while (currentCharacterIndex < stringLength)
        {
            _textComponent.text += stringToDisplay[currentCharacterIndex];
            currentCharacterIndex++;

            if (currentCharacterIndex < stringLength && stringToDisplay[currentCharacterIndex] != ' ')
            {
                if (Input.GetKey(DialogueInput))
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters * CharacterRateMultiplier);
                }
                else
                {
                    yield return new WaitForSeconds(SecondsBetweenCharacters);
                }
            }
        }

        _isStringBeingRevealed = false;
    }
}
