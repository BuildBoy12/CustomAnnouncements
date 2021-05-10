// -----------------------------------------------------------------------
// <copyright file="EscapeClassD.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace CustomAnnouncements.Commands.SubCommands
{
    using System;
    using CommandSystem;
    using Exiled.Permissions.Extensions;

    /// <summary>
    /// A command to play the <see cref="Configs.SubConfigs.EscapeClassD"/> announcement.
    /// </summary>
    public class EscapeClassD : ICommand
    {
        /// <inheritdoc />
        public string Command => "escapeclassd";

        /// <inheritdoc />
        public string[] Aliases { get; } = { "ed" };

        /// <inheritdoc />
        public string Description { get; } = "Views or plays the EscapeClassD announcement.";

        /// <inheritdoc />
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("ca.ed"))
            {
                response = "Insufficient permission. Required: ca.ed";
                return false;
            }

            if (Plugin.Instance.Config.EscapeClassD.IsNullOrEmpty())
            {
                response = "The EscapeClassD announcement is not set in the config.";
                return true;
            }

            if (arguments.Count == 1)
                return Methods.ViewOrPlay(Plugin.Instance.Config.EscapeClassD, "ed", arguments.At(0), out response);

            response = "Syntax: ca ed <v/p>";
            return false;
        }
    }
}