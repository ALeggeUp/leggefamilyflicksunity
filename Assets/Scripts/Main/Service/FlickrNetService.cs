/*
 * FlickrNetService.cs
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

using FlickrNet;

using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace aleggeup.leggefamilyflicks.main
{
    public class FlickrNetService : IFlickrNetService
    {
        private IApplicationConfig config;
        private IPersistentData persistentData;
        private Flickr flickr;

        private RegisterNewUser registerNewUser;

        [Construct]
        public FlickrNetService (IApplicationConfig config, IPersistentData persistentData,
            RegisterNewUser registerNewUser)
        {
            Debug.Log ("FlickrNetService constructor");
            this.config = config;
            this.persistentData = persistentData;
            this.registerNewUser = registerNewUser;
        }

        // PostConstruct methods fire automatically after Construction
        // and after all injections are satisfied. It's a safe place
        // to do things you'd usually consider doing in the Constructor.
        [PostConstruct]
        public void PostConstruct ()
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback (AcceptAllCertifications);
            registerNewUser.AddListener (RegisterNewUser);
            flickr = new Flickr (config.FlickrApplicationKey, config.FlickrApplicationSecret);
        }

        public void RegisterNewUser ()
        {
            Debug.Log ("FlickrNetService RegisterNewUser");
            // flickr.OAuthGetRequestTokenAsync ("oob", new System.Action<FlickrResult<OAuthRequestToken>> (OAuthGetRequestTokenCallback));
            flickr.OAuthGetRequestTokenAsync ("oob", r => {
                OAuthRequestToken requestToken = new OAuthRequestToken ();
                if (r.HasError) {
                    Debug.LogError ("async Error");

                    return;
                } else {
                    requestToken.Token = r.Result.Token;
                    requestToken.TokenSecret = r.Result.TokenSecret;

                    RequestToken prt = new RequestToken () {
                        BinaryTime = 0L,
                        completed = false,
                        Token = requestToken.Token,
                        TokenSecret = requestToken.TokenSecret
                    };

                    persistentData.AddRequestToken (prt);

                    return;
                }
            });
            // Application.OpenURL (authUrl);
        }

        private void OAuthGetRequestTokenCallback (FlickrResult<OAuthRequestToken> request)
        {
            Debug.Log ("OAuthGetRequestTokenCallback!");
            if (request.HasError) {
                Debug.LogError ("Request had error!");
                Debug.LogError (request.ErrorCode);
                Debug.LogError (request.ErrorMessage);
            } else {
                Debug.Log ("Request didn't has error!!");
                OAuthRequestToken accessRequestToken = request.Result;
                Debug.Log ("Token: " + accessRequestToken.Token);
                Debug.Log ("Secret: " + accessRequestToken.TokenSecret);
                string authUrl = flickr.OAuthCalculateAuthorizationUrl (accessRequestToken.Token, AuthLevel.Delete, true);
                Debug.Log ("auth url: " + authUrl);
                /*
                token = new RequestToken () {
                    BinaryTime = 0L,
                    completed = false,
                    ID = 1L,
                    Token = accessRequestToken.Token,
                    TokenSecret = accessRequestToken.TokenSecret
                };
                */
                // RequestToken token = new RequestToken ();
                // addNewRequestTokenSignal.Dispatch (token);
                // persistentData.AddRequestToken (token);
                // isThisSafer (token);
            }
        }

        public bool AcceptAllCertifications (object sender, X509Certificate certification,
            X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
