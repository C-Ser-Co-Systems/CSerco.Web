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
                    if (!CheckIn(user.IdUser))
                    {
                        db.CheckIn.Add(new CheckIn
                        {
                            IdUser = user.IdUser,
                            Fecha = DateTime.Today.Date,
                            Hora = DateTime.Now.ToString("HH:mm:ss"),
                            Status = 1
                        });
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            return false;
        }

        public bool CheckIn(int idUser)
        {
            int count = db.CheckIn.Where(x => x.IdUser == idUser && x.Status == 1).Count();
            if(count == 0)
            {
                return false;
            }
            else
            {
                var userChekIn = db.CheckIn.Where(x => x.IdUser == idUser && x.Status == 1).ToList().LastOrDefault();
                if (userChekIn.Fecha == DateTime.Today.Date)
                {
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