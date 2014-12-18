
using System;
using System.Security.Cryptography;
using System.Text;

namespace tiny.review.core.DataModels
{
    public class User : IDbType
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string EmailAdress { get; set; }

        const string ConstantSalt = "xi07cevs01q4#";
        protected string HashedPassword { get; private set; }
        private string passwordSalt;
        private string PasswordSalt
        {
            get
            {
                return passwordSalt ?? (passwordSalt = Guid.NewGuid().ToString("N"));
            }
            set { passwordSalt = value; }
        }

        public User SetPassword(string pwd)
        {
            HashedPassword = GetHashedPassword(pwd);
            return this;
        }

        private string GetHashedPassword(string pwd)
        {
            using (var sha = SHA256.Create())
            {
                var computedHash = sha.ComputeHash(Encoding.Unicode.GetBytes(PasswordSalt + pwd + ConstantSalt));
                return Convert.ToBase64String(computedHash);
            }
        }

        public bool ValidatePassword(string maybePwd)
        {
            if (HashedPassword == null)
                return true;
            return HashedPassword == GetHashedPassword(maybePwd);
        }

        public void Update(IDbType entity)
        {
            UserId = ((User)entity).UserId;
            UserName = ((User)entity).UserName;
            EmailAdress = ((User)entity).EmailAdress;
        }
    }
}
