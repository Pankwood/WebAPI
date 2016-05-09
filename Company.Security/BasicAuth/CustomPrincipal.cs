#region Licence
//===================================================================================
// Pankwood
//===================================================================================
// Copyright (c) 2016, Pankwood.  All Rights Reserved.
//===================================================================================
#endregion

#region References
using System.Security.Principal;

#endregion

namespace Company.Security.BasicAuth
{
    //Um objeto principal representa o contexto de segurança do usuário, incluindo a identidade do usuário (IIdentity) e todas as funções que a pertencerem.
    public class CustomPrincipal : IPrincipal
    {
        public CustomPrincipal(string user)
        {
            this.Identity = new GenericIdentity(user);
        }

        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            AccessSimulator ac = new AccessSimulator();
            return ac.IsInRole(role);
        }

        public Account GetUsers(string username, string password)
        {
            AccessSimulator ac = new AccessSimulator();
            return ac.GetUsers(username, password);
        }

        public bool GetUser(string username, string password)
        {
            AccessSimulator ac = new AccessSimulator();
            return true;
        }
    }
}