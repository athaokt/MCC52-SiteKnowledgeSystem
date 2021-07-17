using MCC52_SiteKnowledgeSystem.Context;
using MCC52_SiteKnowledgeSystem.Model;
using MCC52_SiteKnowledgeSystem.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MCC52_SiteKnowledgeSystem.Repositories.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        public IConfiguration _configuration;
        private readonly MyContext myContext;
        public AccountRepository(IConfiguration config, MyContext myContext) : base(myContext)
        {
            this._configuration = config;
            this.myContext = myContext;
        }
        public IQueryable GetAllData()
        {
            var employeeRecord = (from e in myContext.Employees
                                  join s in myContext.Sites on e.SiteId equals s.SiteId
                                  join a in myContext.Accounts on e.EmployeeId equals a.EmployeeId
                                  join ar in myContext.AccountRoles on a.EmployeeId equals ar.EmployeeId
                                  join r in myContext.Roles on ar.RoleId equals r.RoleId
                                  select new
                                  {
                                      e.EmployeeId,
                                      e.FullName,
                                      e.Email,
                                      a.Username,
                                      e.PhoneNumber,
                                      e.Gender,
                                      s.SiteName,
                                      r.RoleName
                                  });
            return employeeRecord;
        }

        public IQueryable GetAllData(string employeeId)
        {


            var employeeRecord = (from e in myContext.Employees
                                  join a in myContext.Accounts on e.EmployeeId equals a.EmployeeId
                                  join ar in myContext.AccountRoles on a.EmployeeId equals ar.EmployeeId
                                  join r in myContext.Roles on ar.RoleId equals r.RoleId
                                  join s in myContext.Sites on e.SiteId equals s.SiteId
                                  where e.EmployeeId == $"{employeeId}"
                                  select new
                                  {
                                      e.EmployeeId,
                                      e.FullName,
                                      e.Email,
                                      a.Username,
                                      e.PhoneNumber,
                                      e.Gender,
                                      s.SiteName,
                                      r.RoleName
                                  });

            return employeeRecord;
        }

        public int Login(LoginVM loginVM)
        {
            var login = (from e in myContext.Employees
                         join a in myContext.Accounts on e.EmployeeId equals a.EmployeeId
                         select new
                         {
                             e.Email,
                             a.Username
                         }

                         );
            var cekEmail = myContext.Employees.Where(e => (e.Email == loginVM.Email) ).FirstOrDefault<Employee>();
            var cekUsername = myContext.Accounts.Where(a => (a.Username == loginVM.Username)).FirstOrDefault<Account>();
            if (cekEmail != null)
            {
                var cekPass = BCrypt.Net.BCrypt.Verify(loginVM.Password, cekEmail.Account.Password);
                if (cekPass)
                {

                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public int ResetPassword(ResetPasswordVM resetPasswordVM)
        {
            var cek = myContext.Employees.Where(e => (e.Email == resetPasswordVM.Email)).FirstOrDefault<Employee>();
            if (cek != null)
            {
                Guid g = Guid.NewGuid();
                var getEmail = resetPasswordVM.Email;

                DateTime dateTime = DateTime.Now;
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("oktigalasatha@gmail.com");
                mail.To.Add(getEmail);
                mail.Subject = $"Password Sementara {dateTime}";
                mail.Body = $"Berikut adalah password sementara untuk melakukan reset password:\n{g.ToString()}";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("oktigalasatha@gmail.com", "Atha.1998");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);

                var find = myContext.Employees.Where(e => e.Email == getEmail).FirstOrDefault<Employee>();
                var find2 = myContext.Accounts.Find(find.EmployeeId);

                find2.Password = BCrypt.Net.BCrypt.HashPassword(g.ToString(), GetRandomSalt());

                myContext.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }
        public int ChangePassword(ChangePasswordVM changePasswordVM)
        {
            var cek = myContext.Employees.Where(e => (e.Email == changePasswordVM.Email)).FirstOrDefault<Employee>();
            if (cek != null)
            {
                var cekPass = BCrypt.Net.BCrypt.Verify(changePasswordVM.OldPassword, cek.Account.Password);
                if (cekPass)
                {
                    var change = myContext.Accounts.Find(cek.EmployeeId);
                    change.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordVM.NewPassword, GetRandomSalt());
                    myContext.SaveChanges();
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 0;
            }
        }

        public string GenerateTokenLogin(LoginVM loginVM)
        {
            var data = (
                from account in myContext.Accounts
                join employee in myContext.Employees
                on account.EmployeeId equals employee.EmployeeId
                join accountRole in myContext.AccountRoles
                on account.EmployeeId equals accountRole.EmployeeId
                join role in myContext.Roles
                on accountRole.RoleId equals role.RoleId
                where account.Username == $"{loginVM.Username}" || employee.Email == $"{loginVM.Email}"
                select new
                {
                    EmployeeId = employee.EmployeeId,
                    FullName = employee.FullName,
                    Email = employee.Email,
                    RoleName = role.RoleName
                }).ToList();
            var claims = new List<Claim>();
            foreach (var item in data)
            {
                claims.Add(new Claim("employeeId", item.EmployeeId));
                claims.Add(new Claim("fullName", item.FullName));
                claims.Add(new Claim("email", item.Email));
                claims.Add(new Claim("role", item.RoleName));

            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);
            return new JwtSecurityTokenHandler().WriteToken(token);
            //return Ok(new { status = HttpStatusCode.OK, nik = user.NIK, token = show });
        }

        public List<string> GetDataLogin(LoginVM loginVM)
        {
            List<string> data = new List<string>();
            var getInfo = (from e in myContext.Employees
                           join s in myContext.Sites on e.SiteId equals s.SiteId
                           join a in myContext.Accounts on e.EmployeeId equals a.EmployeeId
                           join ar in myContext.AccountRoles on a.EmployeeId equals ar.EmployeeId
                           join r in myContext.Roles on ar.RoleId equals r.RoleId
                           select new
                           {
                               EmployeeId = e.EmployeeId,
                               FullName = e.FullName,
                               Email = e.Email,
                               Username = a.Username,
                               PhoneNumber = e.PhoneNumber,
                               SiteName = s.SiteName,
                               RoleName = r.RoleName
                           });
            foreach (var item in getInfo)
            {
                data.Add(item.EmployeeId);
                data.Add(item.FullName);
                data.Add(item.Email);
                data.Add(item.Username);
                data.Add(item.PhoneNumber);
                data.Add(item.SiteName);
                data.Add(item.RoleName);
            } 
            return data;
        }

        public static string GetRandomSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12);
        }

    }
}
