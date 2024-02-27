using System;
using System.Collections.Generic;

namespace XrmToolBoxTool_MoveAutomations.AppCode
{
    public static class ErrorHandling
    {
        public static Dictionary<string, string> Errors { get; set; }

        public static void AddError(String process, Exception exception)
        {
            if (Errors == null) Errors = new Dictionary<string, string>();

            Errors.Add(process, exception.Message);
        }

        public static void ClearErrors()
        {
            if (Errors != null) Errors.Clear();
        }

    }
}
