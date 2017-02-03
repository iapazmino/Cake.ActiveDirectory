﻿using System;
using Cake.ActiveDirectory.Users;
using Cake.Core;
using Cake.Core.Annotations;
using Landpy.ActiveDirectory.Core;

namespace Cake.ActiveDirectory {
    /// <summary>
    /// Contains functionality related to managing Active Directory.
    /// </summary>
    [CakeAliasCategory("ActiveDirectory")]
    public static class ActiveDirectoryAliases {
        /// <summary>
        /// Creates a new user in the specified active directory.
        /// </summary>
        /// <example>
        /// <code>
        ///     AddUser("cake-user", "cake-group", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net"});
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="samAccountName">The SAM account name of new user.</param>
        /// <param name="ouDistinguishedName">The distinguished name of the OU.</param>
        /// <param name="settings">The user settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("AddUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void AddUser(this ICakeContext context, string samAccountName, string ouDistinguishedName,
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (string.IsNullOrWhiteSpace(samAccountName)) {
                throw new ArgumentNullException(nameof(samAccountName));
            }
            if (string.IsNullOrWhiteSpace(ouDistinguishedName)) {
                throw new ArgumentNullException(nameof(ouDistinguishedName));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }
           
            var userService = new UserService(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
            userService.AddUser(samAccountName, ouDistinguishedName, settings);
        }

        /// <summary>
        /// Updates a user account given the specified properties.
        /// </summary>
        /// <example>
        /// <code>
        ///     AddUser("employeeId", "1234", new UserSettings { 
        ///         LoginName = "domainAdmin", 
        ///         Password = "adminPassword", 
        ///         DomainName = "Cake.net",
        ///         Email = "test@cake-yeah.com" });
        /// </code>
        /// </example>
        /// <param name="context">The context.</param>
        /// <param name="attributeName">The name of the attribute to search by.</param>
        /// <param name="attributeValue">The value of the attribute to search using.</param>
        /// <param name="settings">The user attribute settings.</param>
        [CakeMethodAlias]
        [CakeAliasCategory("UpdateUser")]
        [CakeNamespaceImport("Cake.ActiveDirectory.Users")]
        public static void UpdateUser(this ICakeContext context, string attributeName, string attributeValue,
            UserSettings settings) {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            if (string.IsNullOrWhiteSpace(attributeName)) {
                throw new ArgumentNullException(nameof(attributeName));
            }
            if (string.IsNullOrWhiteSpace(attributeValue)) {
                throw new ArgumentNullException(nameof(attributeValue));
            }
            if (settings == null) {
                throw new ArgumentNullException(nameof(settings));
            }

            var userService = new UserService(new ADOperator(settings.LoginName, settings.Password, settings.DomainName));
            userService.UpdateUser(attributeName, attributeValue, settings);
        }
    }
}
