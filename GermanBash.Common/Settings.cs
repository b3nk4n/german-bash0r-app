﻿using PhoneKit.Framework.Core.Storage;
using System.Windows.Media;

namespace GermanBash.Common
{
    public static class Settings
    {
        /// <summary>
        /// Setting for the lockscreen background image path in isolated storage.
        /// </summary>
        /// <remarks>
        /// NULL means to load no image, so the user will only see the solid background.
        /// </remarks>
        public static readonly StoredObject<string> LockScreenBackgroundImagePath = new StoredObject<string>("lockBackgroundImagePath", null);

        /// <summary>
        /// Setting for the lockscreen background image opacity in isolated storage.
        /// </summary>
        public static readonly StoredObject<double> LockScreenBackgroundImageOpacity = new StoredObject<double>("lockBackgroundImageOpacity", 0.5);

        /// <summary>
        /// Settings for the lockscreen background solid color.
        /// </summary>
        public static readonly StoredObject<Color> LockScreenBackgroundColor = new StoredObject<Color>("lockBackgroundColor", Colors.Black);
    }
}
