using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ComputersStore.WebUI.Helpers
{
    public class ImageHelper
    {
        public byte[] ConvertImageToByteArray(IFormFile file)
        {
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            return ms.ToArray();
        }

        public string ConvertByteArrayToImageDataUrl(byte[] byteArray)
        {
            string imageBase64Data = Convert.ToBase64String(byteArray);
            return string.Format("data:image/jpg;base64,{0}", imageBase64Data);
        }
    }
}
