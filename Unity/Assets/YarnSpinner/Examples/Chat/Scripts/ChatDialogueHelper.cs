using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Yarn.Unity.Example {
    /// <summary>
    /// clones dialogue bubbles for the ChatDialogue example
    /// </summary>
    public class ChatDialogueHelper : MonoBehaviour
    {
        DialogueRunner runner;

        [Tooltip("This the chat message bubble UI object (what we are cloning!) NOT the container group for all chat bubbles")]
        public GameObject dialogueContainer;
        Text dialogueText;
        bool isFirstMessage = true;

        // current message bubble styling settings, modified by SetSender
        bool isRightAlignment = true;
        Color currentBGColor = Color.black, currentTextColor = Color.white;

        void Awake() {
            runner = GetComponent<DialogueRunner>();
            runner.AddCommandHandler( "Me", SetSenderMe );
            runner.AddCommandHandler( "Them", SetSenderThem );
        }

        void Start () {
            dialogueContainer.SetActive(false);
            UpdateMessageBoxSettings();
        }

        // YarnCommand <<Me>>, but does not use YarnCommand C# attribute, registers in Awake() instead
        public void SetSenderMe(string[] parameters) {
            isRightAlignment = true;
            currentBGColor = Color.blue;
            currentTextColor = Color.white;
        }

        // YarnCommand <<Them>> does not use YarnCommand C# attribute, registers in Awake() instead
        public void SetSenderThem(string[] parameters) {
            isRightAlignment = false;
            currentBGColor = Color.white;
            currentTextColor = Color.black;
        }

        void UpdateMessageBoxSettings() {
            var bg = dialogueContainer.GetComponentInChildren<Image>();
            bg.color = currentBGColor;
            var message = dialogueContainer.GetComponentInChildren<Text>();
            message.text = "";
            message.color = currentTextColor;

            var layoutGroup = dialogueContainer.GetComponent<HorizontalLayoutGroup>();
            if ( isRightAlignment ) {
                layoutGroup.padding.left = 32;
                layoutGroup.padding.right = 0;
                bg.transform.SetAsLastSibling();
            } else {
                layoutGroup.padding.left = 0;
                layoutGroup.padding.right = 32;
                bg.transform.SetAsFirstSibling();
            }
        }

        public void CloneMessageBoxToHistory() {
            // if this isn't the very first message, then clone current message box and move it up
            if ( isFirstMessage == false ) {
                var oldClone = Instantiate( 
                    dialogueContainer, 
                    dialogueContainer.transform.position, 
                    dialogueContainer.transform.rotation, 
                    dialogueContainer.transform.parent
                );
                dialogueContainer.transform.SetAsLastSibling();
            }
            isFirstMessage = false;

            // reset message box and configure based on current settings
            dialogueContainer.SetActive(true);
            UpdateMessageBoxSettings();
        }


    }

}
