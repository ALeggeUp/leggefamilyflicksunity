/*
 * RegistrationItemMediator.cs
 * 
 * Copyright (c) 2015 [ A Legge Up Consulting].  All Rights Reserved.
 * 
 * Unauthorized copying or redistribution of this file in whole or
 * in part, or use in source and binary forms, with or without
 * modification via any medium is strictly prohibited.
 * 
 * Proprietary and confidential.
 * 
 * Created: February 2015
 * Author: Stephen Legge <stephen@aleggeup.com>
 * 
 * THIS IS UNPUBLISHED PROPRIETARY SOURCE CODE OF A LEGGE UP CONSULTING
 * 
 * The copyright notice above does not evidence any
 * actual or intended publication of such source code.
 */

using UnityEngine;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

using System.Collections;

namespace aleggeup.leggefamilyflicks.main
{
    public class RegistrationItemMediator : Mediator
    {
        [Inject]
        public RegistrationItemView view { get; set; }

        public override void OnRegister()
        {
            view.launch.AddListener(OnLaunchRequest);
            view.cancel.AddListener(OnCancelRequest);
            view.Init();
        }

        public override void OnRemove()
        {
            view.launch.RemoveListener(OnLaunchRequest);
            view.cancel.RemoveListener(OnCancelRequest);
        }

        public void OnLaunchRequest() {
            Debug.Log("Launch Request");
        }

        public void OnCancelRequest() {
            Debug.Log("Cancel Request");
        }
    }
}
