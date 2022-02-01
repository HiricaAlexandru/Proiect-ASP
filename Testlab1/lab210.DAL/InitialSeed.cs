using lab210.DAL.Entitati;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab210.DAL
{
    public class InitialSeed
    {
        private readonly RoleManager<Roluri> _roleManager;

        public InitialSeed(RoleManager<Roluri> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void CreateRoles()
        {
            string[] roleNames = {
                                "Admin",
                                "User"
                                };

            foreach (var roleName in roleNames)
            {
                var role = new Roluri
                {
                    Name = roleName
                };
                _roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
