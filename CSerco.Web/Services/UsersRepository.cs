using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.ComponentModel;
using System.Security.Cryptography;
using CSerco.SQL.DataContext;
using CSerco.Web.Models;
using System.Diagnostics;

namespace CSerco.Web.Services
{
    public class UsersRepository
    {
        private readonly CSercoDBEntities1 db = new CSercoDBEntities1();

        public bool AddNewUser(UserVM model)
        {
            try
            {
                Usuarios user = new Usuarios
                {
                    IdRol = model.IdRol,
                    UserName = model.UserName,
                    PasswordHash = Encrypt(model.Password),
                    FechaRegistro = DateTime.Today,
                    FLastUpdate = DateTime.Today,
                    Status = 1
                };
                db.Usuarios.Add(user);
                db.SaveChanges();
                //It´s all good!
                return true;
            }catch(Exception e)
            {
                Debug.WriteLine("Exception Message: " + e.Message);
                return false;
            }
        }

        public List<SelectListItem> getRoles()
        {
            var roleLst = db.RolesUsuario.Where(x => x.Status == 1).ToList();
            List<SelectListItem> roles = new List<SelectListItem>();
            foreach(var item in roleLst)
            {
                roles.Add(new SelectListItem
                {
                    Text = item.RolName,
                    Value = item.IdRol.ToString()
                });
            }

            return roles;
        }

        public String Encrypt(string pass)
        {
            byte[] salt;
            byte[] bytes;
            if (pass == null)
            {
                pass = "DummyPass123";
            }
            using (Rfc2898DeriveBytes rfc2898DeriveByte = new Rfc2898DeriveBytes(pass, 16, 1000))
            {
                salt = rfc2898DeriveByte.Salt;
                bytes = rfc2898DeriveByte.GetBytes(32);
            }
            byte[] numArray = new byte[49];
            Buffer.BlockCopy(salt, 0, numArray, 1, 16);
            Buffer.BlockCopy(bytes, 0, numArray, 17, 32);
            return Convert.ToBase64String(numArray);
        }
    }
}