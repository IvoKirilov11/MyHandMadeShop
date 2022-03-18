namespace MoiteRecepti.Data.Models
{
    using MyHandMadeShop.Data.Common.Models;
    using MyHandMadeShop.Data.Models;
    using System;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int ItemId { get; set; }

        public virtual Item Item { get; set; }

        public string Extension { get; set; }

        //// The contents of the image is in the file system

        public string RemoteImageUrl { get; set; }

    }
}
