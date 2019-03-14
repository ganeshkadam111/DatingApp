﻿using DattingApp.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DattingApp.API.Data
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);

            foreach (var user in users)
            {
                CreatePasswordHash("password", out byte[] passwordHash, out byte[] passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.UserName = user.UserName.ToLower();

                _context.Users.Add(user);
            }

            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwrdHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwrdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
