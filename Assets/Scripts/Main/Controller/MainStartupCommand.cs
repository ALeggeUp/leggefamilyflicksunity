/*
 * MainStartupCommand.cs
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

using strange.extensions.context.api;
using strange.extensions.command.impl;

namespace aleggeup.leggefamilyflicks.main
{
    public class MainStartupCommand : Command
    {
        private DisplayFirstWindow displayFirstWindow;

        [Construct]
        public MainStartupCommand (DisplayFirstWindow displayFirstWindow) : base()
        {
            this.displayFirstWindow = displayFirstWindow;
        }

        override public void Execute ()
        {
            Debug.Log ("MainStartupCommand.Execute()");
            displayFirstWindow.Dispatch ();
        }
    }
}
