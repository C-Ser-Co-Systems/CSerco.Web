using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using CSerco.Web.Models;
using CSerco.SQL.DataContext;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CSerco.Web.Services
{
    public class ManageRepository
    {
        readonly CSercoDBEntities1 db = new CSercoDBEntities1();
        readonly SessionData session = new SessionData();
        public bool IniciarSesion(SignInVM model)
        {
            int userExist = db.Usuarios.Where(x => x.UserName == model.UserName && x.Status != 0).Count();
            if (userExist > 0)
            {
                var user = db.Usuarios.Where(x => x.UserName == model.UserName).Single();
                if (ValidationPassword(user.IdUser, model.Password))
                {
                    session.setSession("User", user.IdUser);
                    session.setSession("Rol", user.IdRol);
                    return true;
                }
            }

            return false;
        }

        bool ValidationPassword(int idUser, string pass)
        {
            var hasher = new PasswordHasher();

            var user = db.Usuarios.Where(x => x.IdUser == idUser && x.Status != 0).Single();
            var Result = hasher.VerifyHashedPassword(user.PasswordHash.ToString(), pass);

            if (Result != PasswordVerificationResult.Failed)
            {
                return true;
            }

            return false;
        }
    }
}