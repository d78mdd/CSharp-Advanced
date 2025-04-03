using BlackFriday.Core.Contracts;
using BlackFriday.Models;
using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Core
{
    public class Controller : IController
    {
        private string[] validProductTypes = new[]
        {
            "Item",
            "Service",
        };

        private IApplication application;

        public Controller()
        {
            this.application = new Application();
        }

        public string RegisterUser(string userName, string email, bool hasDataAccess)
        {
            bool nameExists = application.Users.Exists(userName);

            if (nameExists)
            {
                return string.Format(OutputMessages.UserAlreadyRegistered, userName);
            }

            bool emailExists = application.Users.Models.Any(u => u.Email == email);

            if (emailExists)
            {
                return string.Format(OutputMessages.SameEmailIsRegistered, email);
            }

            IUser user;
            string result = "";

            if (hasDataAccess)
            {
                int adminCount = application.Users.Models.Count(m => m.HasDataAccess);

                if (adminCount >= 2)
                {
                    return string.Format(OutputMessages.AdminCountLimited);
                }

                user = new Admin(userName, email);

                result = string.Format(OutputMessages.AdminRegistered, userName);
            }
            else
            {
                user = new Client(userName, email);

                result = string.Format(OutputMessages.ClientRegistered, userName);
            }

            application.Users.AddNew(user);

            return result;
        }

        public string AddProduct(string productType, string productName, string userName, double basePrice)
        {
            if (!validProductTypes.Contains(productType))
            {
                return string.Format(OutputMessages.ProductIsNotPresented, productType);
            }

            if (application.Products.Exists(productName))
            {
                return string.Format(OutputMessages.ProductNameDuplicated, productName);
            }

            IUser user = application.Users.GetByName(userName);

            if (user == null || user is Client)
            {
                return string.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            IProduct product;

            if (productType == "Item")
            {
                product = new Item(productName, basePrice);
            }
            else
            {
                product = new Service(productName, basePrice);
            }

            application.Products.AddNew(product);

            return string.Format(OutputMessages.ProductAdded, productType, productName, $"{basePrice:F2}");
        }

        public string UpdateProductPrice(string productName, string userName, double newPriceValue)
        {
            if (!application.Products.Exists(productName))
            {
                return string.Format(OutputMessages.ProductDoesNotExist, productName);
            }

            IUser user = application.Users.GetByName(userName);

            if (user == null || user is Client)
            {
                return string.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            IProduct product = application.Products.GetByName(productName);

            double oldPrice = product.BasePrice;

            product.UpdatePrice(newPriceValue);

            return string.Format(OutputMessages.ProductPriceUpdated, productName, $"{oldPrice:F2}", $"{newPriceValue:F2}");
        }

        public string PurchaseProduct(string userName, string productName, bool blackFridayFlag)
        {
            IUser user = application.Users.GetByName(userName);

            if (user == null || user is Admin)
            {
                return string.Format(OutputMessages.UserIsNotClient, userName);
            }

            if (!application.Products.Exists(productName))
            {
                return string.Format(OutputMessages.ProductDoesNotExist, productName);
            }

            IProduct product = application.Products.GetByName(productName);

            if (product.IsSold)
            {
                return string.Format(OutputMessages.ProductOutOfStock, productName);
            }

            product.ToggleStatus(); // status always become true
            Client client = (Client)user;
            client.PurchaseProduct(product.ProductName, blackFridayFlag);

            double price = product.BasePrice;
            if (blackFridayFlag)
            {
                price = product.BlackFridayPrice;
            }

            return string.Format(OutputMessages.ProductPurchased, userName, productName, $"{price:F2}");
        }

        public string RefreshSalesList(string userName)
        {
            IUser user = application.Users.GetByName(userName);

            if (user == null || user is Client)
            {
                return string.Format(OutputMessages.UserIsNotAdmin, userName);
            }

            List<IProduct> soldProduct = application.Products.Models.Where(p => p.IsSold)
                .ToList();

            soldProduct.ForEach(p => p.ToggleStatus());

            return string.Format(OutputMessages.SalesListRefreshed, soldProduct.Count());
        }

        public string ApplicationReport()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Application administration:");

            List<IUser> admins = application.Users.Models
                .Where(user => user. GetType() == typeof(Admin))
                .OrderBy(user => user.UserName)
                .ToList();

            foreach (IUser admin in admins)
            {
                sb.AppendLine(admin.ToString());
            }

            List<Client> clients = application.Users.Models
                .Where(user => user.GetType() == typeof(Client))
                .OrderBy(user => user.UserName)
                .Select(user => (Client) user)
                .ToList();

            sb.AppendLine("Clients:");

            foreach (Client client in clients)
            {
                sb.AppendLine(client.ToString());
                if (client.Purchases.Values.Any(v => v))
                {
                    sb.AppendLine($"-Black Friday Purchases: "  +
                                  $"{client.Purchases.Values.Where(v => v).Count()}");

                }

                foreach (var (purchase, promotion) in client.Purchases.Where(pair => pair.Value))
                {
                    sb.AppendLine($"--{purchase}");
                }

            }

            return sb.ToString().Trim();
        }

    }
}
