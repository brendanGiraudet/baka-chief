﻿using bakaChiefApplication.Enums;

namespace bakaChiefApplication.Constants
{
    public class PagesUrl
    {
        public static string GetRecipFormUrl(FormMode formMode, string? recipId = null) => recipId != null ? $"/recips/{formMode}/{recipId}" : $"/recips/{formMode}";

        public static string RecipsUrl => $"/recips";
    }
}