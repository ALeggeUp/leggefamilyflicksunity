/*
 * MainContext.cs
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

using strange.extensions.context.impl;
using strange.extensions.aleggeup.context;

using System;

namespace aleggeup.leggefamilyflicks.main
{
    public class MainContext : SignalContext
    {
        public MainContext (MonoBehaviour contextView) : base (contextView)
        {
        }

        protected override void mapBindings ()
        {
            base.mapBindings ();

            if (Context.firstContext == this) {
                injectionBinder.Bind<IApplicationConfig> ().To<ApplicationConfig> ().ToSingleton ();
                injectionBinder.Bind<IPersistentData> ().To<PersistentData> ().ToSingleton ();
                injectionBinder.Bind<IFlickrNetService> ().To<FlickrNetService> ().ToSingleton ();

                injectionBinder.Bind<DisplayFirstWindow> ().ToSingleton ();
                injectionBinder.Bind<AddNewRequestTokenSignal> ().ToSingleton ();
                injectionBinder.Bind<RequestTokenListSignal> ().ToSingleton ();
                injectionBinder.Bind<NoUserSignal> ().ToSingleton ();
                injectionBinder.Bind<RegisterNewUser> ().ToSingleton ();

                mediationBinder.BindView<UserMenuView> ().ToMediator<UserMenuMediator> ();
                mediationBinder.BindView<MainMenuView> ().ToMediator<MainMenuMediator> ();
                mediationBinder.BindView<RegistrationItemView>().ToMediator<RegistrationItemMediator>();
            }

            // Eager
            injectionBinder.GetInstance<IFlickrNetService> ();

            commandBinder.Bind<ContextLaunchSignal> ().To<MainStartupCommand> ().Once ();
        }
    }
}
