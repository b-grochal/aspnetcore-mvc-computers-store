using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.Converters
{
    public class ImageByteArrayConverter : ITypeConverter<byte[], string>
    {
        public string Convert(byte[] source, string destination, ResolutionContext context)
        {
            string imageBase64Data = System.Convert.ToBase64String(source);
            return string.Format("data:image/jpg;base64,{0}", imageBase64Data);
        }
    }
}
