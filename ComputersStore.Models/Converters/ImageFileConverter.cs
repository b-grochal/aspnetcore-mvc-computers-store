using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ComputersStore.Models.Converters
{
    public class ImageFileConverter : ITypeConverter<IFormFile, byte[]>
    {
        public byte[] Convert(IFormFile source, byte[] destination, ResolutionContext context)
        {
            MemoryStream ms = new MemoryStream();
            source.CopyTo(ms);
            return ms.ToArray();
        }
    }
}
