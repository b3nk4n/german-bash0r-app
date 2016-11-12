﻿using GermanBash.App.Resources;

namespace GermanBash.App.Controls
{
    public class LocalizedBackupControl : MyBackupControlBase
    {
        public LocalizedBackupControl()
        {
            DataContext = new BackupControlViewModel();
        }

        /// <summary>
        /// Localizes the user controls contents and texts.
        /// </summary>
        protected override void LocalizeContent()
        {
            CreateBackupHeaderText = AppResources.CreateBackupHeaderText;
            RestoreBackupHeaderText = AppResources.RestoreBackupHeaderText;
            NameOfBackupHintText = AppResources.NameOfBackupHintText;
            BackupInfoText = AppResources.BackupInfoText;
            AttentionTitle = AppResources.AttentionTitle;
            RestoreInfoText = AppResources.RestoreInfoText;
            CommonBackupWarningText = AppResources.CommonBackupWarningText;
            LoginText = AppResources.Login;
        }
    }
}
