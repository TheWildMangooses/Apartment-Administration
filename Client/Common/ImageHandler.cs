using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace Client.Common
{
    public class ByteArrayImageConverter 
    {

        public BitmapImage GetImage(byte[] value)
        {
            
            return ByteToImage(value).Result;
        }

        public byte[] SelectImage()
        {
            return ImageToByte().Result;
        }

        public async Task<byte[]> ImageToByte()
        {
            //call this when selecting an image from the picker  
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".bmp");
            picker.FileTypeFilter.Add(".png");
            picker.FileTypeFilter.Add(".jpg");
            StorageFile file = await picker.PickSingleFileAsync();
            using (var inputStream = await file.OpenSequentialReadAsync())
            {
                var readStream = inputStream.AsStreamForRead();
                byte[] buffer = new byte[readStream.Length];
                await readStream.ReadAsync(buffer, 0, buffer.Length);
                return buffer;
            }
        }

   

        public async Task<BitmapImage> ByteToImage(byte[] byteArray)
        {
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(stream.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(byteArray);
                    await writer.StoreAsync();
                }
                BitmapImage image = new BitmapImage();
                await image.SetSourceAsync(stream);
                return image;
            }
        }
    }
}
