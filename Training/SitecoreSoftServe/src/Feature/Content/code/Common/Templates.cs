using Sitecore.Data;
using Sitecore.Publishing.Pipelines.PublishItem;

namespace SitecoreSoftServe.Feature.Content.Common
{
    public class Templates
    {
        public static class About
        {
            public static readonly ID TemplateId = new ID("{81006D2C-BAC3-4AA2-9D6B-95CEEDCBD3D4}");
            public static readonly ID Title = new ID("{7E1987D4-6008-4518-964E-4E6BFFD49F78}");
            public static readonly ID Text = new ID("{6694D625-407B-4D28-AB17-29522E26BDC4}");
            public static readonly ID Link = new ID("{02637C00-F3D5-4940-98D5-D4BAA5E3017B}");
            public static readonly ID Image = new ID("{69CA55EE-DF75-4A3F-A2FD-76660778C677}");

            public static class RenderingParameters
            {
                public static readonly string IsImageLeftSide = "isImageLeftSide";
            }
        }

        public static class Testimonial
        {
            public static readonly ID TemplateId = new ID("{82FF7D85-F630-4A45-A534-E2729F394D33}");
            public static readonly ID AuthorImage = new ID("{AD890FFA-8CA0-46FF-A999-73C024D380A2}");
            public static readonly ID Text = new ID("{B4D163A3-1E5A-491C-A5BE-33B8D419CB03}");
            public static readonly ID BackgroundImage = new ID("{FA407774-6123-4ACA-8B28-113D0C961D0A}");
        }

        public static class FunFactor
        {
            public static readonly ID Number = new ID("{53B900AC-AC7D-4692-ABEC-ABFEF5DDA5D3}");
            public static readonly ID Title = new ID("{5D2A568E-1A50-4B30-903C-94FF49F32A08}");
        }
    }
}