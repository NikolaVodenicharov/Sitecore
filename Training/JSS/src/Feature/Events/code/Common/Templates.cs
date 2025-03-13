using Sitecore.Data;

namespace SoftServeJss.Feature.JssEvents.Common
{
    public class Templates
    {
        public static class EventList
        {
            public static readonly ID TemplateId = new ID("{9EB8955A-D33B-49B2-820E-9648D3FE3FB8}");
            public static readonly ID Title = new ID("{6DF5FB60-5AB7-4785-942B-296791EB5043}");
            public static readonly ID Description = new ID("{7687CD50-AF87-4757-86C5-D078B962B8BD}");
        }

        public static class EventInfo
        {
            public static readonly ID TemplateId = new ID("{2301B9B0-2A56-4857-BBE0-C8BD86091D4E}");

            public static readonly ID Title = new ID("{83CDCF14-FE49-44BE-881B-43851E237DC9}");
            public static readonly ID Description = new ID("{CB740C59-BA85-4849-AC43-860527CFE42D}");
            public static readonly ID Image = new ID("{43F5EC05-96C4-4564-AF4E-90E04658A675}");
        }

        public static class EventWhereabouts
        {
            public static readonly ID StartDate = new ID("{EB0275B8-659A-43FC-91E6-CBB444549912}");
            public static readonly ID EndDate = new ID("{31C12B65-05BF-4369-80B0-071B4A3E7D65}");
            public static readonly ID Location = new ID("{46EDD4DE-3267-4D37-8F09-167D425B812F}");

            public const string StartDateIndexFieldName = "Empty";
            public const string EndDateIndexFieldName = "Empty";
        }
    }
}