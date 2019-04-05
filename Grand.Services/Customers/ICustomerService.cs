using Grand.Core;
using Grand.Core.Domain.Common;
using Grand.Core.Domain.Customers;
using Grand.Core.Domain.Orders;
using Grand.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Grand.Services.Customers
{
    /// <summary>
    /// Customer service interface
    /// </summary>
    public partial interface ICustomerService
    {
        #region Customers

        /// <summary>
        /// Gets all customers
        /// </summary>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="affiliateId">Affiliate identifier</param>
        /// <param name="vendorId">Vendor identifier</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="email">Email; null to load all customers</param>
        /// <param name="username">Username; null to load all customers</param>
        /// <param name="firstName">First name; null to load all customers</param>
        /// <param name="lastName">Last name; null to load all customers</param>
        /// <param name="dayOfBirth">Day of birth; 0 to load all customers</param>
        /// <param name="monthOfBirth">Month of birth; 0 to load all customers</param>
        /// <param name="company">Company; null to load all customers</param>
        /// <param name="phone">Phone; null to load all customers</param>
        /// <param name="zipPostalCode">Phone; null to load all customers</param>
        /// <param name="loadOnlyWithShoppingCart">Value indicating whether to load customers only with shopping cart</param>
        /// <param name="sct">Value indicating what shopping cart type to filter; userd when 'loadOnlyWithShoppingCart' param is 'true'</param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Customers</returns>
        Task<IPagedList<Customer>> GetAllCustomers(DateTime? createdFromUtc = null,
            DateTime? createdToUtc = null, string affiliateId = "", string vendorId = "",
            string[] customerRoleIds = null, string[] customerTagIds = null, string email = null, string username = null,
            string firstName = null, string lastName = null,
            string company = null, string phone = null, string zipPostalCode = null,
            bool loadOnlyWithShoppingCart = false, ShoppingCartType? sct = null,
            int pageIndex = 0, int pageSize = int.MaxValue); //Int32.MaxValue

        /// <summary>
        /// Gets all customers by customer format (including deleted ones)
        /// </summary>
        /// <param name="passwordFormat">Password format</param>
        /// <returns>Customers</returns>
        Task<IList<Customer>> GetAllCustomersByPasswordFormat(PasswordFormat passwordFormat);

        /// <summary>
        /// Gets online customers
        /// </summary>
        /// <param name="lastActivityFromUtc">Customer last activity date (from)</param>
        /// <param name="customerRoleIds">A list of customer role identifiers to filter by (at least one match); pass null or empty list in order to load all customers; </param>
        /// <param name="pageIndex">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns>Customers</returns>
        Task<IPagedList<Customer>> GetOnlineCustomers(DateTime lastActivityFromUtc,
            string[] customerRoleIds, int pageIndex = 0, int pageSize = int.MaxValue);

        int GetCountOnlineShoppingCart(DateTime lastActivityFromUtc);

        /// <summary>
        /// Delete a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task DeleteCustomer(Customer customer);

        /// <summary>
        /// Gets a customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <returns>A customer</returns>
        Task<Customer> GetCustomerById(string customerId);

        /// <summary>
        /// Get customers by identifiers
        /// </summary>
        /// <param name="customerIds">Customer identifiers</param>
        /// <returns>Customers</returns>
        Task<IList<Customer>> GetCustomersByIds(string[] customerIds);

        /// <summary>
        /// Gets a customer by GUID
        /// </summary>
        /// <param name="customerGuid">Customer GUID</param>
        /// <returns>A customer</returns>
        Task<Customer> GetCustomerByGuid(Guid customerGuid);

        /// <summary>
        /// Get customer by email
        /// </summary>
        /// <param name="email">Email</param>
        /// <returns>Customer</returns>
        Task<Customer> GetCustomerByEmail(string email);

        /// <summary>
        /// Get customer by system role
        /// </summary>
        /// <param name="systemName">System name</param>
        /// <returns>Customer</returns>
        Task<Customer> GetCustomerBySystemName(string systemName);

        /// <summary>
        /// Get customer by username
        /// </summary>
        /// <param name="username">Username</param>
        /// <returns>Customer</returns>
        Task<Customer> GetCustomerByUsername(string username);

        /// <summary>
        /// Insert a guest customer
        /// </summary>
        /// <returns>Customer</returns>
        Task<Customer> InsertGuestCustomer(Store store, string urlreferrer = "");

        /// <summary>
        /// Insert a customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task InsertCustomer(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomer(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerLastActivityDate(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerVendor(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerPassword(Customer customer);


        /// <summary>
        /// Update free shipping
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="freeShipping"></param>
        Task UpdateFreeShipping(string customerId, bool freeShipping);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateAffiliate(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateActive(Customer customer);

        /// <summary>
        /// Update the customer
        /// </summary>
        /// <param name="customer"></param>
        Task UpdateContributions(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerLastLoginDate(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerLastIpAddress(Customer customer);

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerLastPurchaseDate(string customerId, DateTime date);
        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerLastUpdateCartDate(string customerId, DateTime? date);
        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerLastUpdateWishList(string customerId, DateTime date);
        /// <summary>
        /// Updates the customer in admin panel
        /// </summary>
        /// <param name="customer">Customer</param>
        Task UpdateCustomerinAdminPanel(Customer customer);

        /// <summary>
        /// Reset data required for checkout
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="storeId">Store identifier</param>
        /// <param name="clearCouponCodes">A value indicating whether to clear coupon code</param>
        /// <param name="clearCheckoutAttributes">A value indicating whether to clear selected checkout attributes</param>
        /// <param name="clearRewardPoints">A value indicating whether to clear "Use reward points" flag</param>
        /// <param name="clearShippingMethod">A value indicating whether to clear selected shipping method</param>
        /// <param name="clearPaymentMethod">A value indicating whether to clear selected payment method</param>
        Task ResetCheckoutData(Customer customer, string storeId,
            bool clearCouponCodes = false, bool clearCheckoutAttributes = false,
            bool clearRewardPoints = true, bool clearShippingMethod = true,
            bool clearPaymentMethod = true);

        /// <summary>
        /// Update Customer Reminder History
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="orderId"></param>
        Task UpdateCustomerReminderHistory(string customerId, string orderId);


        /// <summary>
        /// Delete guest customer records
        /// </summary>
        /// <param name="createdFromUtc">Created date from (UTC); null to load all records</param>
        /// <param name="createdToUtc">Created date to (UTC); null to load all records</param>
        /// <param name="onlyWithoutShoppingCart">A value indicating whether to delete customers only without shopping cart</param>
        /// <returns>Number of deleted customers</returns>
        Task<int> DeleteGuestCustomers(DateTime? createdFromUtc, DateTime? createdToUtc, bool onlyWithoutShoppingCart);

        #endregion

        #region Password history

        /// <summary>
        /// Gets customer passwords
        /// </summary>
        /// <param name="customerId">Customer identifier; pass null to load all records</param>
        /// <param name="passwordsToReturn">Number of returning passwords; pass null to load all records</param>
        /// <returns>List of customer passwords</returns>
        Task<IList<CustomerHistoryPassword>> GetPasswords(string customerId, int passwordsToReturn);

        /// <summary>
        /// Insert a customer history password
        /// </summary>
        /// <param name="customer">Customer</param>
        Task InsertCustomerPassword(Customer customer);


        #endregion

        #region Customer roles

        /// <summary>
        /// Inserts a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        Task InsertCustomerRole(CustomerRole customerRole);

        /// <summary>
        /// Updates the customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        Task UpdateCustomerRole(CustomerRole customerRole);

        /// <summary>
        /// Delete a customer role
        /// </summary>
        /// <param name="customerRole">Customer role</param>
        Task DeleteCustomerRole(CustomerRole customerRole);

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="customerRoleId">Customer role identifier</param>
        /// <returns>Customer role</returns>
        Task<CustomerRole> GetCustomerRoleById(string customerRoleId);

        /// <summary>
        /// Gets a customer role
        /// </summary>
        /// <param name="systemName">Customer role system name</param>
        /// <returns>Customer role</returns>
        Task<CustomerRole> GetCustomerRoleBySystemName(string systemName);

        /// <summary>
        /// Gets all customer roles
        /// </summary>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Customer roles</returns>
        Task<IList<CustomerRole>> GetAllCustomerRoles(bool showHidden = false);

        /// <summary>
        /// Gets customer roles products for customer role
        /// </summary>
        /// <param name="customerRoleId">Customer role id</param>
        /// <returns>Customer role products</returns>
        Task<IList<CustomerRoleProduct>> GetCustomerRoleProducts(string customerRoleId);

        /// <summary>
        /// Gets customer roles products for customer role
        /// </summary>
        /// <param name="customerRoleId">Customer role id</param>
        /// <param name="productId">Product id</param>
        /// <returns>Customer role product</returns>
        Task<CustomerRoleProduct> GetCustomerRoleProduct(string customerRoleId, string productId);

        /// <summary>
        /// Gets customer roles product
        /// </summary>
        /// <param name="Id">id</param>
        /// <returns>Customer role product</returns>
        Task<CustomerRoleProduct> GetCustomerRoleProductById(string id);

        /// <summary>
        /// Inserts a customer role product
        /// </summary>
        /// <param name="customerRoleProduct">Customer role product</param>
        Task InsertCustomerRoleProduct(CustomerRoleProduct customerRoleProduct);

        /// <summary>
        /// Updates the customer role product
        /// </summary>
        /// <param name="customerRoleProduct">Customer role product</param>
        Task UpdateCustomerRoleProduct(CustomerRoleProduct customerRoleProduct);

        /// <summary>
        /// Delete a customer role product
        /// </summary>
        /// <param name="customerRoleProduct">Customer role product</param>
        Task DeleteCustomerRoleProduct(CustomerRoleProduct customerRoleProduct);

        #endregion

        #region Customer Role in Customer

        Task InsertCustomerRoleInCustomer(CustomerRole customerRole);

        Task DeleteCustomerRoleInCustomer(CustomerRole customerRole);

        #endregion

        #region Customer address

        Task DeleteAddress(Address address);
        Task InsertAddress(Address address);
        Task UpdateAddress(Address address);
        Task UpdateBillingAddress(Address address);
        Task UpdateShippingAddress(Address address);
        Task RemoveShippingAddress(string customerId);

        #endregion

        #region Shopping cart 

        Task ClearShoppingCartItem(string customerId, string storeId, ShoppingCartType shoppingCartType);
        Task DeleteShoppingCartItem(string customerId, ShoppingCartItem shoppingCartItem);
        Task InsertShoppingCartItem(string customerId, ShoppingCartItem shoppingCartItem);
        Task UpdateShoppingCartItem(string customerId, ShoppingCartItem shoppingCartItem);
        #endregion

        #region Customer Product Price

        /// <summary>
        /// Gets a customer product price
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Customer product price</returns>
        Task<CustomerProductPrice> GetCustomerProductPriceById(string id);

        /// <summary>
        /// Gets a price
        /// </summary>
        /// <param name="customerId">Customer Identifier</param>
        /// <param name="productId">Product Identifier</param>
        /// <returns>Customer product price</returns>
        Task<decimal?> GetPriceByCustomerProduct(string customerId, string productId);

        /// <summary>
        /// Gets a customer product 
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Customer product</returns>
        Task<CustomerProduct> GetCustomerProduct(string id);

        /// <summary>
        /// Gets a customer product 
        /// </summary>
        /// <param name="customerId">Customer Identifier</param>
        /// <param name="productId">Product Identifier</param>
        /// <returns>Customer product</returns>
        Task<CustomerProduct> GetCustomerProduct(string customerId, string productId);

        /// <summary>
        /// Inserts a customer product price
        /// </summary>
        /// <param name="customerProductPrice">Customer product price</param>
        Task InsertCustomerProductPrice(CustomerProductPrice customerProductPrice);

        /// <summary>
        /// Updates the customer product price
        /// </summary>
        /// <param name="customerProductPrice">Customer product price</param>
        Task UpdateCustomerProductPrice(CustomerProductPrice customerProductPrice);

        /// <summary>
        /// Delete a customer product price
        /// </summary>
        /// <param name="customerProductPrice">Customer product price</param>
        Task DeleteCustomerProductPrice(CustomerProductPrice customerProductPrice);



        /// <summary>
        /// Gets products price for customer
        /// </summary>
        /// <param name="customerId">Customer id</param>
        /// <returns>Customer products price</returns>
        Task<IPagedList<CustomerProductPrice>> GetProductsPriceByCustomer(string customerId, int pageIndex = 0, int pageSize = int.MaxValue);

        #endregion

        #region Customer product

        /// <summary>
        /// Inserts a customer product 
        /// </summary>
        /// <param name="customerProduct">Customer product</param>
        Task InsertCustomerProduct(CustomerProduct customerProduct);

        /// <summary>
        /// Updates the customer product
        /// </summary>
        /// <param name="customerProduct">Customer product </param>
        Task UpdateCustomerProduct(CustomerProduct customerProduct);

        /// <summary>
        /// Delete a customer product 
        /// </summary>
        /// <param name="customerProduct">Customer product </param>
        Task DeleteCustomerProduct(CustomerProduct customerProduct);

        Task<IPagedList<CustomerProduct>> GetProductsByCustomer(string customerId, int pageIndex = 0, int pageSize = int.MaxValue);

        #endregion

        #region Customer note

        // <summary>
        /// Get note for customer
        /// </summary>
        /// <param name="id">Note identifier</param>
        /// <returns>CustomerNote</returns>
        Task<CustomerNote> GetCustomerNote(string id);

        /// <summary>
        /// Deletes an customer note
        /// </summary>
        /// <param name="customerNote">The customer note</param>
        Task DeleteCustomerNote(CustomerNote customerNote);

        /// <summary>
        /// Insert an customer note
        /// </summary>
        /// <param name="customerNote">The customer note</param>
        Task InsertCustomerNote(CustomerNote customerNote);

        /// <summary>
        /// Get notes for customer
        /// </summary>
        /// <param name="customerId">Customer identifier</param>
        /// <param name="displaytocustomer">Display to customer</param>
        /// <returns>OrderNote</returns>
        Task<IList<CustomerNote>> GetCustomerNotes(string customerId, bool? displaytocustomer = null);

        #endregion
    }
}