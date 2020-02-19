/*

The MIT License (MIT)

Copyright (c) 2015-2017 Secret Lab Pty. Ltd. and Yarn Spinner contributors.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Yarn.Unity.Example {
    /// <summary>
    /// displays dialogue and choices for the chat messages example!
    /// for convenience, this inherits from DialogueUI instead of DialogueUIBehavior,
    /// so make sure you read the base class DialogueUI to know what's happening
    /// </summary>
    public class ChatDialogueUI : Yarn.Unity.DialogueUI
    {
        DialogueRunner runner;

        string currentName;
        Vector3 currentAlignment;

        void Awake() {
            runner = GetComponent<DialogueRunner>();

            runner.AddCommandHandler( "Name", SetName );
        }

        // Yarn command to set the current name, message alignment (left or right), and bg color
        public void SetName(params string[] parameters) {
            // change displayed name

            // change message alignment

            // change bg color
        }

        public void CloneMessageBoxToHistory() {
            // clone current message box and move it up
            var oldClone = Instantiate( 
                dialogueContainer, 
                dialogueContainer.transform.position, 
                dialogueContainer.transform.rotation, 
                dialogueContainer.transform.parent
            );
            dialogueContainer.transform.SetAsLastSibling();

            // reset message box and configure based on current settings
        }


    }

}
