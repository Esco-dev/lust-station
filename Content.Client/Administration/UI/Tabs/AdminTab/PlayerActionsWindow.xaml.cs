﻿using Content.Shared.Administration;
using JetBrains.Annotations;
using Robust.Client.AutoGenerated;
using Robust.Client.Console;
using Robust.Client.UserInterface.Controls;
using Robust.Client.UserInterface.CustomControls;
using Robust.Client.UserInterface.XAML;
using Robust.Shared.Utility;

namespace Content.Client.Administration.UI.Tabs.AdminTab
{
    [GenerateTypedNameReferences]
    [UsedImplicitly]
    public sealed partial class PlayerActionsWindow : DefaultWindow
    {
        private PlayerInfo? _selectedPlayer;
        private readonly Dictionary<Button, ConfirmationData> _confirmations = new();

        public PlayerActionsWindow()
        {
            RobustXamlLoader.Load(this);

            SubmitKickButton.OnPressed += SubmitKickButtonOnPressed;
            SubmitAHelpButton.OnPressed += SubmitAhelpButtonOnPressed;
            SubmitRespawnButton.OnPressed += SubmitRespawnButtonOnPressed;
            ScreenshotButton.OnPressed += ScreenshotButtonOnPressed;  // Sunrise-edit
            PlayerList.OnSelectionChanged += OnListOnOnSelectionChanged;
        }

        private void OnListOnOnSelectionChanged(PlayerInfo? obj)
        {
            if (_selectedPlayer != obj)
                AdminUIHelpers.RemoveAllConfirms(_confirmations);

            _selectedPlayer = obj;
            var disableButtons = _selectedPlayer == null;
            SubmitKickButton.Disabled = disableButtons;
            SubmitAHelpButton.Disabled = disableButtons;
            SubmitRespawnButton.Disabled = disableButtons;
            ScreenshotButton.Disabled = disableButtons; // Sunrise-edit
        }

        // Sunrise-start
        private void ScreenshotButtonOnPressed(BaseButton.ButtonEventArgs obj)
        {
            if (_selectedPlayer == null)
                return;

            if (!AdminUIHelpers.TryConfirm(ScreenshotButton, _confirmations))
                return;

            IoCManager.Resolve<IClientConsoleHost>().ExecuteCommand($"screenshot \"{_selectedPlayer.Username}\"");
        }
        // Sunrise-end

        private void SubmitKickButtonOnPressed(BaseButton.ButtonEventArgs obj)
        {
            if (_selectedPlayer == null)
                return;

            if (!AdminUIHelpers.TryConfirm(SubmitKickButton, _confirmations))
                return;

            IoCManager.Resolve<IClientConsoleHost>().ExecuteCommand(
                $"kick \"{_selectedPlayer.Username}\" \"{CommandParsing.Escape(ReasonLine.Text)}\"");
        }

        private void SubmitAhelpButtonOnPressed(BaseButton.ButtonEventArgs obj)
        {
            if (_selectedPlayer == null)
                return;

            IoCManager.Resolve<IClientConsoleHost>().ExecuteCommand(
                $"openahelp \"{_selectedPlayer.SessionId}\"");
        }

        private void SubmitRespawnButtonOnPressed(BaseButton.ButtonEventArgs obj)
        {
            if (_selectedPlayer == null)
                return;

            if (!AdminUIHelpers.TryConfirm(SubmitRespawnButton, _confirmations))
                return;

            IoCManager.Resolve<IClientConsoleHost>().ExecuteCommand(
                $"respawn \"{_selectedPlayer.Username}\"");
        }
    }
}
