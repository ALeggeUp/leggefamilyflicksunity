/*
 * MainMenuMediator.cs
 * 
 * Copyright (c) 2015 [ A Legge Up Consulting].  All Rights Reserved.
 * 
 * Unauthorized copying or redistribution of this file in whole or
 * in part, or use in source and binary forms, with or without
 * modification via any medium is strictly prohibited.
 * 
 * Proprietary and confidential.
 * 
 * Created: January 2015
 * Author: Stephen Legge <stephen@aleggeup.com>
 * 
 * THIS IS UNPUBLISHED PROPRIETARY SOURCE CODE OF A LEGGE UP CONSULTING
 * 
 * The copyright notice above does not evidence any
 * actual or intended publication of such source code.
 */

using UnityEngine;
using System.Collections;

using strange.extensions.mediation.impl;
using strange.extensions.signal.impl;

namespace aleggeup.leggefamilyflicks.main
{
    public class MainMenuMediator : Mediator
    {
        [Inject]
        public MainMenuView view{ get; set; }

        [Inject]
        public NoUserSignal noUserSignal{ get; set;}

        public override void OnRegister ()
        {
            noUserSignal.AddListener (test);
        }

        public override void OnRemove ()
        {
            noUserSignal.RemoveListener (test);
        }

        public void test() {
            // view.Toggler ();
        }
    }
}
