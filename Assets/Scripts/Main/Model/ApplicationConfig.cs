/*
 * ApplicationConfig.cs
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

namespace aleggeup.leggefamilyflicks.main
{
    public class ApplicationConfig : IApplicationConfig
    {
        private static string APP_CONFIG = "JSON/AppConfig";

        public string FlickrApplicationKey { get; private set; }
        public string FlickrApplicationSecret { get; private set; }

        [PostConstruct]
        public void PostConstruct ()
        {
            TextAsset file = Resources.Load (APP_CONFIG) as TextAsset;

            var node = SimpleJSON.JSON.Parse (file.text);

            FlickrApplicationKey = node ["FlickrApplicationKey"];
            FlickrApplicationSecret = node ["FlickrApplicationSecret"];
        }
    }
}
