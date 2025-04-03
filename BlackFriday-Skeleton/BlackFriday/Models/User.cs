using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        protected User(string userName, string email, bool hasDataAccess)
        {
            this.UserName = userName;
            this.Email = email;
            HasDataAccess = hasDataAccess;
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.UserNameRequired);
                }
                userName = value;
            }
        }


        private bool hasDataAccess;

        public bool HasDataAccess
        {
            get { return hasDataAccess; }
            private set { hasDataAccess = value; }
        }



        private string email;
        public string Email
        {
            get
            {
                if (!HasDataAccess)
                {
                    return email;
                }
                else
                {
                    return "hidden";
                }

            }
            private set
            {

                if (String.IsNullOrWhiteSpace(value))
                {
                    if (!HasDataAccess)
                    {
                        throw new ArgumentException(ExceptionMessages.EmailRequired);
                    }
                    else
                    {
                        email = "hidden";
                    }
                }

                email = value;
            }
        }


        public override string ToString()
        {
            string childClassName = this.GetType().Name;

            return $"{UserName} - Status: {childClassName}, Contact Info: {Email}";
        }
    }
}
