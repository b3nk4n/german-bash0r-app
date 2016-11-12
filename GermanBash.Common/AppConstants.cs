using System.Windows.Media;

namespace GermanBash.Common
{
    /// <summary>
    /// Gloabal application constants
    /// </summary>
    public static class AppConstants
    {
        public const string PARAM_ACTION = "action";
        public const string PARAM_TERM = "term";
        public const string PARAM_TYPE = "vote_type";
        public const string PARAM_ID = "id";
        public const string PARAM_ORDER = "order";
        public const string PARAM_NUMBER = "number";
        public const string PARAM_PAGE = "page";
        public const string PARAM_FAVORITES = "favorites";

        public const string ORDER_VALUE_LATEST = "latest";
        public const string ORDER_VALUE_TOP = "top";
        public const string ORDER_VALUE_FLOP = "flop";
        public const string ORDER_VALUE_RANDOM = "random";

        public const string ACTION_VOTE = "vote";
        public const string METHOD_SEARCH = "search";

        public const string TYPE_VALUE_POS = "pos";
        public const string TYPE_VALUE_NEG = "neg";

        public static readonly Color[] COLORS = { 
            Color.FromArgb(255,169,31,28), // (1) #a91f1c
            Color.FromArgb(255, 99,24,21), // (8)
            Color.FromArgb(255,139,28,25), // (4)
            Color.FromArgb(255,119,26,23), // (6)
            Color.FromArgb(255,159,30,27), // (2)
            Color.FromArgb(255,109,25,22), // (7)
            Color.FromArgb(255,149,29,26), // (3)
            Color.FromArgb(255,129,27,24)  // (5)
            };

        public static readonly Color SERVER_COLOR = Color.FromArgb(255, 124, 124, 124); // #7c7c7c

        public const string IAP_AWESOME_EDITION = "awesome_edition";

        public const string BACKGROUND_TASK_NAME = "GermanBash.BackgroundTask";
        public const string BACKGROUND_TASK_DESC = "Aktualisiert deinen Sperrbildschirm in regelmäßigen Zeitabständen.";
    }
}
