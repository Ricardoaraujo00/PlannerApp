using System;
using System.Collections.Generic;
using System.Text;

namespace PlannerApp.Shared.Models
{
    public class UserManagerResponse
    {
        public string message { get; set; }

        public bool isSuccess { get; set; }

        public string[] Errors { get; set; }

        public Dictionary<string,string> userInfo { get; set; }

        public DateTime? ExpireDate { get; set; }

    }
}
