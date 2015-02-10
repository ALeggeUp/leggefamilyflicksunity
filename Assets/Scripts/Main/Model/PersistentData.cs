/*
 * PersistentData.cs
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

using iBoxDB.LocalServer;

using System;
using System.Collections.Generic;

namespace aleggeup.leggefamilyflicks.main
{
    public class PersistentData : IPersistentData
    {
        private static int DB_ID = 1;
        private DB.AutoBox db;

        private AddNewRequestTokenSignal addNewRequestTokenSignal;

        [Construct]
        public PersistentData(AddNewRequestTokenSignal addNewRequestTokenSignal) {
            this.addNewRequestTokenSignal = addNewRequestTokenSignal;
        }

        [PostConstruct]
        public void PostConstruct ()
        {
            Debug.Log ("Persistent Data Path: " + Application.persistentDataPath);
            DB.Root (Application.persistentDataPath);
            var server = new DB (DB_ID);
            server.MinConfig ();
            server.GetConfig ().EnsureTable<User> ("Users", "UserId");
            server.GetConfig ().EnsureTable<RequestToken> ("RequestTokens", "ID");
            db = server.Open ();
            addNewRequestTokenSignal.AddListener (AddRequestToken);
        }

        public int NumberOfTokens { get { return (int)db.Cube ().SelectCount ("from RequestTokens"); } }

        public int NumberOfUsers { get { return (int)db.Cube ().SelectCount ("from Users"); } }

        public List<IRequestToken> RequestTokens {
            get {
                IBEnumerable<RequestToken> requestTokens = db.Select<RequestToken> ("from RequestTokens");
                List<IRequestToken> tokenList = new List<IRequestToken> ();
                foreach (RequestToken token in requestTokens) {
                    tokenList.Add (token);
                }

                return tokenList;
            }
        }

        public List<IUserModel> Users {
            get {
                IBEnumerable<User> users = db.Select<User> ("from Users");
                List<IUserModel> userList = new List<IUserModel> ();
                foreach (User user in users) {
                    userList.Add (user);
                }

                return userList;
            }
        }

        public void AddRequestToken (IRequestToken token)
        {
            token.ID = db.Id (DB_ID);
            try {
                bool res = db.Insert ("RequestTokens", token as RequestToken);
                if (res) {
                    Debug.Log ("db.insert success");
                } else {
                    Debug.Log ("db.insert failed");
                }
            } catch (Exception e) {
                Debug.LogError (e.Message);
            }
        }

    }
}
