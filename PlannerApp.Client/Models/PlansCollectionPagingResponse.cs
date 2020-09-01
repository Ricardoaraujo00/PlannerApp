﻿namespace PlannerApp.Client.Models
{
    public class PlansCollectionPagingResponse : BaseApiResponse
    {
        public Plan[] Records { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? NextPage { get; set; }

    }
}