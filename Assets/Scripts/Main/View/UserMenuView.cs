/*
 * UserMenuView.cs
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

using strange.extensions.signal.impl;
using strange.extensions.mediation.impl;

namespace aleggeup.leggefamilyflicks.main
{
    public class UserMenuView : View
    {
        private static string ANIMATION_OPEN_STATE = "Open";

        internal Signal registerNewUserSignal = new Signal ();

        private Animator animator;

        [PostConstruct]
        public void PostConstruct ()
        {
            animator = transform.GetComponent<Animator> ();
        }

        public string MyName ()
        {
            return transform.name;
        }

        public void DisplayWindow ()
        {
            SetWindowState (true);
        }

        public void HideWindow ()
        {
            SetWindowState (false);
        }

        public void ToggleDisplay ()
        {
            SetWindowState (!animator.GetBool (ANIMATION_OPEN_STATE));
        }

        public void SetWindowState (bool state)
        {
            animator.SetBool (ANIMATION_OPEN_STATE, state);
        }

        public void registerTrigger ()
        {
            registerNewUserSignal.Dispatch ();
        }
    }
}
