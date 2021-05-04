/**
OwnerHandler.cs

Copyright (c) 2021 Dango

This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/
using System.Collections.Generic;
using MonobitEngine;
using UnityEngine;
using MonoBehaviour = UnityEngine.MonoBehaviour;

namespace MunCommunication {
    /// <summary>
    /// Configure MonoBehavior.enabled by ownership of attached object.
    /// </summary>
    public class OwnerHandler : MunMonoBehaviour {
        [SerializeField] private List<MonoBehaviour> enableIfOwner;
        [SerializeField] private List<MonoBehaviour> disableIfOwner;
        
        // Start is called before the first frame update
        void Start() {
            configComponents();
        }
        
        /// <summary>
        /// Check ownership, and configure "enabled" property.
        /// </summary>
        void configComponents() {
            bool isOwner = monobitView.isMine;
            enableIfOwner.ForEach(behaviour => { behaviour.enabled = isOwner;});
            disableIfOwner.ForEach(behaviour => { behaviour.enabled = !isOwner;});
        }
    }
}
