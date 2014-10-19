﻿using GermanBash.App.Resources;
using PhoneKit.Framework.Controls;
using System;

namespace GermanBash.App.Controls
{
    public class LocalizedAboutControl : ThemedAboutControlBase
    {
        /// <summary>
        /// Localizes the user controls contents and texts.
        /// </summary>
        protected override void LocalizeContent()
        {
            // app
            ApplicationIconSource = new Uri("/Assets/ApplicationIcon.png", UriKind.Relative);
            ApplicationTitle = AppResources.ApplicationTitle;
            ApplicationVersion = AppResources.ApplicationVersion;
            ApplicationAuthor = AppResources.ApplicationAuthor;
            ApplicationDescription = AppResources.ApplicationDescription;

            // buttons
            SupportAndFeedbackText = AppResources.SupportAndFeedback;
            SupportAndFeedbackEmail = "apps@bsautermeister.de";
            PrivacyInfoText = AppResources.PrivacyInfo;
            PrivacyInfoLink = "http://bsautermeister.de/privacy.php";
            RateAndReviewText = AppResources.RateAndReview;
            MoreAppsText = AppResources.MoreApps;
            MoreAppsSearchTerms = "Benjamin Sautermeister";

            // contributors
            ContributorsListVisibility = System.Windows.Visibility.Visible;
            ContributorsList.Items.Add(new ContributorModel("/Assets/germanbash.png", AppResources.ContributorsDescriptionBash));
            ContributorsList.Items.Add(new ContributorModel("/Assets/icon.png", "Laurent Sutterlity (The Noun Project)"));
            ContributorsList.Items.Add(new ContributorModel("/Assets/icon.png", "iconsmind.com (The Noun Project)"));
            ContributorsList.Items.Add(new ContributorModel("/Assets/icon.png", "Cengiz SARI (The Noun Project)"));
        }
    }
}
