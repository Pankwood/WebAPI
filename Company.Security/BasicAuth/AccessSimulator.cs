#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System;
using System.Collections.Generic;
using System.Linq; 
#endregion

namespace Company.Security.BasicAuth
{
    public class AccessSimulator
    {
        private List<Account> listAccount = new List<Account>();

        public AccessSimulator()
        {
            listAccount.Add(new Account { Username = "acc1", Password = "123", Roles = new string[] { "superadmin", "addmin", "employee" } });
            listAccount.Add(new Account { Username = "acc2", Password = "123", Roles = new string[] { "addmin", "employee" } });
            listAccount.Add(new Account { Username = "acc3", Password = "123", Roles = new string[] { "employee" } });
        }

        public Account GetUsers(string username, string password)
        {
            return listAccount.Where(acc => acc.Username.Equals(username) && acc.Password.Equals(password)).FirstOrDefault();
        }

        internal bool IsInRole(string role)
        {
            return true;
        }
    }

    public class Account
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}